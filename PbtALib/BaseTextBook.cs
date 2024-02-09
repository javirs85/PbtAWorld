using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class BaseTextBook
{
	public enum TagIDs
	{
		Aplicado, armadura1, armadura2, armadura3, incomodo, torpe, daño1, daño2, daño3, peligroso, Contundente, ignoraArmadura,
		escabroso, penentrante1, penentrante2, penentrante3, preciso, lento, Cerca, lejos, Alcance, tocar,
		arcano, batallon, plaga, auge, artesania, suciedad, Divino, enano, elfico, intimo,
		Magico,	Astuto,	Amorfo,	Organizado,	Inteligente, Acaparador, Sigiloso,	Aterrador,	Cauteloso,	Constructo,	Planar,
		Horda, Grupo, Solitario, Minusculo, Pequeño, Grande, Enorme
	}

	public List<Tag> AllTags = new List<Tag> {
		new Tag(BaseTextBook.TagIDs.Magico, "Mágico","Es mágico por naturaleza de principio a fin."),
		new Tag(BaseTextBook.TagIDs.Astuto, "Astuto","Su principal peligro va más allá del simple choque de la batalla."),
		new Tag(BaseTextBook.TagIDs.Amorfo, "Amorfo","Su anatomía y órganos son extraños e antinaturales."),
		new Tag(BaseTextBook.TagIDs.Organizado, "Organizado","Tiene una estructura grupal que le ayuda en su supervivencia. Derrotar a uno puede provocar la ira de otros. Uno puede dar la alarma."),
		new Tag(BaseTextBook.TagIDs.Inteligente, "Inteligente","Es lo suficientemente inteligente como para que algunos individuos adquieran otras habilidades. El GM puede adaptar al monstruo agregando etiquetas para reflejar entrenamiento específico, como un mago o guerrero."),
		new Tag(BaseTextBook.TagIDs.Acaparador, "Acaparador","Casi con certeza tiene tesoro."),
		new Tag(BaseTextBook.TagIDs.Sigiloso, "Sigiloso","Puede evitar la detección y prefiere atacar con el elemento de sorpresa."),
		new Tag(BaseTextBook.TagIDs.Aterrador, "Aterrador","Su presencia y apariencia evocan miedo."),
		new Tag(BaseTextBook.TagIDs.Cauteloso, "Cauteloso","Valora la supervivencia sobre la agresión."),
		new Tag(BaseTextBook.TagIDs.Constructo, "Constructo","Fue creado, no nació."),
		new Tag(BaseTextBook.TagIDs.Planar, "Planar","Es de más allá de este mundo."),

		new Tag(BaseTextBook.TagIDs.Horda, "Horda","Donde hay uno, hay más. Muchos más."),
		new Tag(BaseTextBook.TagIDs.Grupo, "Grupo","Normalmente se ve en pequeños números, alrededor de 3-6 o algo así."),
		new Tag(BaseTextBook.TagIDs.Solitario, "Solitario","Vive y lucha solo."),


		new Tag(BaseTextBook.TagIDs.Minusculo, "Minúsculo","Es mucho más pequeño que un humano."),
		new Tag(BaseTextBook.TagIDs.Pequeño, "Pequeño","Es del tamaño de un humano."),
		new Tag(BaseTextBook.TagIDs.Grande, "Grande","Es mucho más grande que un humano, aproximadamente del tamaño de un carro."),
		new Tag(BaseTextBook.TagIDs.Enorme, "Enorme","Es tan grande como una casa pequeña o más grande."),



		new Tag(BaseTextBook.TagIDs.Aplicado, "Aplicado", "Solo es útil cuando se aplica cuidadosamente, se come o se bebe"),
		new Tag(BaseTextBook.TagIDs.armadura1, "Armadura+1","Suma uno a tu armadura (acumulable)"),
		new Tag(BaseTextBook.TagIDs.armadura2, "Armadura+2","Suma dos a tu armadura (acumulable)"),
		new Tag(BaseTextBook.TagIDs.armadura3, "Armadura+3","Suma tres a tu armadura (acumulable)"),
		new Tag(BaseTextBook.TagIDs.incomodo, "Incómodo","Es difícil de manejar y de usar"),
		new Tag(BaseTextBook.TagIDs.torpe, "Torpe","Es difícil moverse, -1 continuo mientras se carga"),
		new Tag(BaseTextBook.TagIDs.daño1, "Daño+1","Daño +1, acumulable"),
		new Tag(BaseTextBook.TagIDs.daño2, "Daño+2","Daño +2, acumulable"),
		new Tag(BaseTextBook.TagIDs.daño3, "Daño+3","Daño +3, acumulable"),
		new Tag(BaseTextBook.TagIDs.peligroso, "Peligroso","Si lo utilizas sin tomar las precauciones adecuadas, espera consecuencias"),
		new Tag(BaseTextBook.TagIDs.Contundente, "Contundente","cuando se usa como un arma, es capaz de derribar a alguien"),
		new Tag(BaseTextBook.TagIDs.ignoraArmadura, "Ignora armadura","La armadura no se resta al daño realizado por este objeto"),
		new Tag(BaseTextBook.TagIDs.escabroso, "Escabroso","Causa daño de una forma particularmente destructiva, destrozando personas y cosas"),
		new Tag(BaseTextBook.TagIDs.penentrante1, "Penetrante-1","Recude la armadura del defensor en -1"),
		new Tag(BaseTextBook.TagIDs.penentrante2, "Penetrante-2","Recude la armadura del defensor en -2"),
		new Tag(BaseTextBook.TagIDs.penentrante3, "Penetrante-3","Recude la armadura del defensor en -3"),
		new Tag(BaseTextBook.TagIDs.preciso, "Preciso","Puedes tirar DEX en vez de FUE"),
		new Tag(BaseTextBook.TagIDs.lento, "Lento","Lleva más que un momento para usarlo"),
	


		new Tag(BaseTextBook.TagIDs.arcano, "Arcano","Alguien de notable poder arcano vive aquí."),
		new Tag(BaseTextBook.TagIDs.batallon, "Batallón","Unos 1000 hombres armados y preparados"),
		new Tag(BaseTextBook.TagIDs.plaga, "Plaga","El lugar tiene un problema recurrente, normalmente una infestación de monstruos"),
		new Tag(BaseTextBook.TagIDs.auge, "Auge","Mucha más gente que espacio disponible"),
		new Tag(BaseTextBook.TagIDs.artesania, "Artesanía","El lugar es famoso por su maestría en la artesanía listada"),
		new Tag(BaseTextBook.TagIDs.suciedad, "Suciedad","Nada a la venta, mano de obra barata"),
		new Tag(BaseTextBook.TagIDs.Divino, "Divino","Una organización religiosa notable reside aquí"),
		new Tag(BaseTextBook.TagIDs.enano, "Enano","mayormente poblado por enanos"),
		new Tag(BaseTextBook.TagIDs.elfico, "Élfico","mayormente poblado por elfos"),

		new Tag(BaseTextBook.TagIDs.Cerca, "cerca","Es útil para atacar a alguien a uno o dos pies más allá del alcance del brazo."),
		new Tag(BaseTextBook.TagIDs.lejos, "Lejos","Es útil para disparar a distancia"),
		new Tag(BaseTextBook.TagIDs.Alcance, "Alcance","Útil para atacar a varios pies de distancia, hasta 10 (3m)"),
		new Tag(BaseTextBook.TagIDs.tocar, "Tocar","Se puede usar para atacar a alguien a un brazo o menos de distancia"),
		new Tag(BaseTextBook.TagIDs.intimo, "Íntimo","útil para atacar a alguien a quien puedes ver el blanco de los ojos"),		
	};
}
