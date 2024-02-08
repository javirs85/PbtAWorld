using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWorld;

public enum BasicMonsterTags
{
    Magico,
    Astuto,
    Amorfo,
    Organizado,
    Inteligente,
    Acaparador,
    Sigiloso,
    Aterrador,
    Cauteloso,
    Constructo,
    Planar
}

public enum OrganizationMonsterTags
{
    Horda,
    Grupo,
    Solitario
}

public enum SizeMonsterTags
{
    Minúsculo,
    Pequeño,
    Grande,
    Enorme
}

public enum RangeMonsterTags
{
    Mano,
    Cercano,
    Alcance,
    Cerca,
    Lejos
}

public enum Locations
{
    Cavernas, Pantano, NoMuerto, Bosque,Horda, Experimentos, Profundidades, Planar
}

public static class MonsterTagExtensions
{
    public static string Description(this BasicMonsterTags tag)
    {
        switch (tag)
        {
            case BasicMonsterTags.Magico:
                return "Es mágico por naturaleza de principio a fin.";
            case BasicMonsterTags.Astuto:
                return "Su principal peligro va más allá del simple choque de la batalla.";
            case BasicMonsterTags.Amorfo:
                return "Su anatomía y órganos son extraños e antinaturales.";
            case BasicMonsterTags.Organizado:
                return "Tiene una estructura grupal que le ayuda en su supervivencia. Derrotar a uno puede provocar la ira de otros. Uno puede dar la alarma.";
            case BasicMonsterTags.Inteligente:
                return "Es lo suficientemente inteligente como para que algunos individuos adquieran otras habilidades. El GM puede adaptar al monstruo agregando etiquetas para reflejar entrenamiento específico, como un mago o guerrero.";
            case BasicMonsterTags.Acaparador:
                return "Casi con certeza tiene tesoro.";
            case BasicMonsterTags.Sigiloso:
                return "Puede evitar la detección y prefiere atacar con el elemento de sorpresa.";
            case BasicMonsterTags.Aterrador:
                return "Su presencia y apariencia evocan miedo.";
            case BasicMonsterTags.Cauteloso:
                return "Valora la supervivencia sobre la agresión.";
            case BasicMonsterTags.Constructo:
                return "Fue creado, no nació.";
            case BasicMonsterTags.Planar:
                return "Es de más allá de este mundo.";
            default:
                throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
        }
    }

    public static string Description(this RangeMonsterTags tag)
    {
        switch (tag)
        {
            case RangeMonsterTags.Mano:
                return "Es útil para atacar algo al alcance de tu mano, no más lejos.";
            case RangeMonsterTags.Cercano:
                return "Es útil para atacar algo al alcance de tu brazo más un pie o dos.";
            case RangeMonsterTags.Alcance:
                return "Es útil para atacar algo que está a varios pies de distancia, tal vez hasta diez.";
            case RangeMonsterTags.Cerca:
                return "Es útil para atacar si puedes ver los blancos de sus ojos.";
            case RangeMonsterTags.Lejos:
                return "Es útil para atacar algo a distancia de gritos.";
            default:
                throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
        }
    }

    public static string Description(this OrganizationMonsterTags tag)
    {
        switch (tag)
        {
            case OrganizationMonsterTags.Horda:
                return "Donde hay uno, hay más. Muchos más.";
            case OrganizationMonsterTags.Grupo:
                return "Normalmente se ve en pequeños números, alrededor de 3-6 o algo así.";
            case OrganizationMonsterTags.Solitario:
                return "Vive y lucha solo.";
            default:
                throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
        }
    }

    public static string Description(this SizeMonsterTags tag)
    {
        switch (tag)
        {
            case SizeMonsterTags.Minúsculo:
                return "Es mucho más pequeño que un semigigante.";
            case SizeMonsterTags.Pequeño:
                return "Es del tamaño de un semigigante.";
            case SizeMonsterTags.Grande:
                return "Es mucho más grande que un humano, aproximadamente del tamaño de un carro.";
            case SizeMonsterTags.Enorme:
                return "Es tan grande como una casa pequeña o más grande.";
            default:
                throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
        }
    }
}
