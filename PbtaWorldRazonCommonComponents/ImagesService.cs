using Microsoft.AspNetCore.Components.Forms;
using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PbtaWorldRazonCommonComponents;

public class ImagesService
{
	public event EventHandler UpdateUI;
	public event EventHandler<string> OnNewError;
	public event EventHandler<PbtAImage> ForceFullScreenImageOnPlayers;

	public Guid GameID { get; set; }
	public string RootPath => "./wwwroot/GameImages/" + GameID.ToString();
	public string RootURL => "/GameImages/" + GameID.ToString();
	public string InfoFile => RootPath + "/"+ GameID.ToString() + ".json";

	public List<PbtAImage> AllImages { get; set; } = new();

	private void LoadAllImagesFromFolder()
	{
		var files = System.IO.Directory.GetFiles(RootPath).Where(x=>Path.GetExtension(x) != ".json");
		List<PbtAImage> tempList = new();

		foreach (var file in files)
		{
			var fileName = Path.GetFileNameWithoutExtension(file);
			
			var existing = AllImages.Find(x=> x.Name == fileName);
			if(existing is null)
			{ 
				tempList.Add(new PbtAImage
				{
					IsVisibleForPlayers = false,
					Name = fileName,
					src = RootURL + "/" + Path.GetFileName(file),
				});
			}
			else
			{
				tempList.Add(existing);
			}
		}

		AllImages = tempList;

		ForeceUpdateInAllClients();
	}

	public void ForeceUpdateInAllClients() => UpdateUI?.Invoke(this, EventArgs.Empty);

	public async Task SaveImagesInfo()
	{
		System.IO.Directory.CreateDirectory(RootPath);
		var json = JsonSerializer.Serialize(AllImages);
		await File.WriteAllTextAsync(InfoFile, json);
	}
	public async Task LoadAll()
	{
		Directory.CreateDirectory(RootPath);

		if(File.Exists(InfoFile))
		{
			var json = await File.ReadAllTextAsync(InfoFile);
			var tempList = JsonSerializer.Deserialize<List<PbtAImage>>(json);

			LoadAllImagesFromFolder();

			foreach (var item in AllImages)
			{
				var existing = tempList.Find(x => x.Name == item.Name);
				if (existing is not null)
				{
					item.Name = existing.Name;
					item.src = existing.src;
					item.IsVisibleForPlayers = existing.IsVisibleForPlayers;
				}
			}
		}
		else
		{
			LoadAllImagesFromFolder();
		}

		ForeceUpdateInAllClients();
	}

	public async Task SaveImageToDisk(InputFileChangeEventArgs e)
	{
		var maxFileSize = 10 * 1024 * 1024; // 10 MB as an example, you can adjust this

		var file = e.File;

		if (file != null)
		{
			if (file.Size > maxFileSize)
			{
				OnNewError?.Invoke(this, "File cannot be bigger than 10Mg");
			}
			else
			{
				var fileName = Path.Combine(RootPath, file.Name);

				using (var stream = file.OpenReadStream(maxFileSize))
				{
					using (var fileStream = new FileStream(fileName, FileMode.Create))
					{
						await stream.CopyToAsync(fileStream);
					}
				}
			}
		}

		await LoadAll();
		await SaveImagesInfo();
	}

	public async Task RenameFile(PbtAImage img, string newName)
	{
		try
		{
			var path = Path.Combine(RootPath, img.Name);
			var ext = Path.GetExtension(img.src);
			var oldPath = path + ext;
			var newPath = Path.Combine(RootPath, newName + ext);

			File.Move(oldPath, newPath);

			await LoadAll();
		}
		catch (Exception e)
		{
			OnNewError?.Invoke(this, e.Message);
		}

		
	}

	public void SendImageToAllPlayers(PbtAImage image) => ForceFullScreenImageOnPlayers?.Invoke(this, image);

	public void DeleteImage(PbtAImage image)
	{
		AllImages.Remove(image);

		var FilePath = "./wwwroot" + image.src;

		if (File.Exists(FilePath))
			System.IO.File.Delete(FilePath);

		ForeceUpdateInAllClients();
	}
}
