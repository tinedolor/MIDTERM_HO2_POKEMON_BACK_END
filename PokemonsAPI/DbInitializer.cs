using Microsoft.EntityFrameworkCore;
using PokemonsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonsAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PokemonContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pokemons.Any())
            {
                return; // DB has been seeded
            }

            var pokemons = CreatePokemonList();
            context.Pokemons.AddRange(pokemons);
            context.SaveChanges();

            SetEvolutionRelationships(context);
        }

        private static List<Pokemon> CreatePokemonList()
        {
            return new List<Pokemon>
            {
                // ===== GENERATION 1 (KANTO) =====
                // Bulbasaur Line
                new Pokemon { Id = 1, Name = "Bulbasaur", Type = "Grass/Poison", Generation = 1 },
                new Pokemon { Id = 2, Name = "Ivysaur", Type = "Grass/Poison", Generation = 1 },
                new Pokemon { Id = 3, Name = "Venusaur", Type = "Grass/Poison", Generation = 1 },
                
                // Charmander Line
                new Pokemon { Id = 4, Name = "Charmander", Type = "Fire", Generation = 1 },
                new Pokemon { Id = 5, Name = "Charmeleon", Type = "Fire", Generation = 1 },
                new Pokemon { Id = 6, Name = "Charizard", Type = "Fire/Flying", Generation = 1 },
                
                // Squirtle Line
                new Pokemon { Id = 7, Name = "Squirtle", Type = "Water", Generation = 1 },
                new Pokemon { Id = 8, Name = "Wartortle", Type = "Water", Generation = 1 },
                new Pokemon { Id = 9, Name = "Blastoise", Type = "Water", Generation = 1 },
                
                // Caterpie Line
                new Pokemon { Id = 10, Name = "Caterpie", Type = "Bug", Generation = 1 },
                new Pokemon { Id = 11, Name = "Metapod", Type = "Bug", Generation = 1 },
                new Pokemon { Id = 12, Name = "Butterfree", Type = "Bug/Flying", Generation = 1 },
                
                // Weedle Line
                new Pokemon { Id = 13, Name = "Weedle", Type = "Bug/Poison", Generation = 1 },
                new Pokemon { Id = 14, Name = "Kakuna", Type = "Bug/Poison", Generation = 1 },
                new Pokemon { Id = 15, Name = "Beedrill", Type = "Bug/Poison", Generation = 1 },
                
                // Pidgey Line
                new Pokemon { Id = 16, Name = "Pidgey", Type = "Normal/Flying", Generation = 1 },
                new Pokemon { Id = 17, Name = "Pidgeotto", Type = "Normal/Flying", Generation = 1 },
                new Pokemon { Id = 18, Name = "Pidgeot", Type = "Normal/Flying", Generation = 1 },
                
                // Rattata Line
                new Pokemon { Id = 19, Name = "Rattata", Type = "Normal", Generation = 1 },
                new Pokemon { Id = 20, Name = "Raticate", Type = "Normal", Generation = 1 },
                
                // Spearow Line
                new Pokemon { Id = 21, Name = "Spearow", Type = "Normal/Flying", Generation = 1 },
                new Pokemon { Id = 22, Name = "Fearow", Type = "Normal/Flying", Generation = 1 },
                
                // Pikachu Line
                new Pokemon { Id = 25, Name = "Pikachu", Type = "Electric", Generation = 1 },
                new Pokemon { Id = 26, Name = "Raichu", Type = "Electric", Generation = 1 },
                
                // Sandshrew Line
                new Pokemon { Id = 27, Name = "Sandshrew", Type = "Ground", Generation = 1 },
                new Pokemon { Id = 28, Name = "Sandslash", Type = "Ground", Generation = 1 },
                
                // Nidoran Lines
                new Pokemon { Id = 29, Name = "Nidoran♀", Type = "Poison", Generation = 1 },
                new Pokemon { Id = 30, Name = "Nidorina", Type = "Poison", Generation = 1 },
                new Pokemon { Id = 31, Name = "Nidoqueen", Type = "Poison/Ground", Generation = 1 },

                new Pokemon { Id = 32, Name = "Nidoran♂", Type = "Poison", Generation = 1 },
                new Pokemon { Id = 33, Name = "Nidorino", Type = "Poison", Generation = 1 },
                new Pokemon { Id = 34, Name = "Nidoking", Type = "Poison/Ground", Generation = 1 },
                
                // Clefairy Line
                new Pokemon { Id = 35, Name = "Clefairy", Type = "Fairy", Generation = 1 },
                new Pokemon { Id = 36, Name = "Clefable", Type = "Fairy", Generation = 1 },
                
                // Vulpix Line
                new Pokemon { Id = 37, Name = "Vulpix", Type = "Fire", Generation = 1 },
                new Pokemon { Id = 38, Name = "Ninetales", Type = "Fire", Generation = 1 },
                
                // Jigglypuff Line
                new Pokemon { Id = 39, Name = "Jigglypuff", Type = "Normal/Fairy", Generation = 1 },
                new Pokemon { Id = 40, Name = "Wigglytuff", Type = "Normal/Fairy", Generation = 1 },
                
                // Zubat Line
                new Pokemon { Id = 41, Name = "Zubat", Type = "Poison/Flying", Generation = 1 },
                new Pokemon { Id = 42, Name = "Golbat", Type = "Poison/Flying", Generation = 1 },
                
                // Oddish Line
                new Pokemon { Id = 43, Name = "Oddish", Type = "Grass/Poison", Generation = 1 },
                new Pokemon { Id = 44, Name = "Gloom", Type = "Grass/Poison", Generation = 1 },
                new Pokemon { Id = 45, Name = "Vileplume", Type = "Grass/Poison", Generation = 1 },
                
                // Paras Line
                new Pokemon { Id = 46, Name = "Paras", Type = "Bug/Grass", Generation = 1 },
                new Pokemon { Id = 47, Name = "Parasect", Type = "Bug/Grass", Generation = 1 },
                
                // Venonat Line
                new Pokemon { Id = 48, Name = "Venonat", Type = "Bug/Poison", Generation = 1 },
                new Pokemon { Id = 49, Name = "Venomoth", Type = "Bug/Poison", Generation = 1 },
                
                // Diglett Line
                new Pokemon { Id = 50, Name = "Diglett", Type = "Ground", Generation = 1 },
                new Pokemon { Id = 51, Name = "Dugtrio", Type = "Ground", Generation = 1 },
                
                // Meowth Line
                new Pokemon { Id = 52, Name = "Meowth", Type = "Normal", Generation = 1 },
                new Pokemon { Id = 53, Name = "Persian", Type = "Normal", Generation = 1 },
                
                // Psyduck Line
                new Pokemon { Id = 54, Name = "Psyduck", Type = "Water", Generation = 1 },
                new Pokemon { Id = 55, Name = "Golduck", Type = "Water", Generation = 1 },
                
                // Mankey Line
                new Pokemon { Id = 56, Name = "Mankey", Type = "Fighting", Generation = 1 },
                new Pokemon { Id = 57, Name = "Primeape", Type = "Fighting", Generation = 1 },
                
                // Growlithe Line
                new Pokemon { Id = 58, Name = "Growlithe", Type = "Fire", Generation = 1 },
                new Pokemon { Id = 59, Name = "Arcanine", Type = "Fire", Generation = 1 },
                
                // Poliwag Line
                new Pokemon { Id = 60, Name = "Poliwag", Type = "Water", Generation = 1 },
                new Pokemon { Id = 61, Name = "Poliwhirl", Type = "Water", Generation = 1 },
                new Pokemon { Id = 62, Name = "Poliwrath", Type = "Water/Fighting", Generation = 1 },
                
                // Abra Line
                new Pokemon { Id = 63, Name = "Abra", Type = "Psychic", Generation = 1 },
                new Pokemon { Id = 64, Name = "Kadabra", Type = "Psychic", Generation = 1 },
                new Pokemon { Id = 65, Name = "Alakazam", Type = "Psychic", Generation = 1 },
                
                // Machop Line
                new Pokemon { Id = 66, Name = "Machop", Type = "Fighting", Generation = 1 },
                new Pokemon { Id = 67, Name = "Machoke", Type = "Fighting", Generation = 1 },
                new Pokemon { Id = 68, Name = "Machamp", Type = "Fighting", Generation = 1 },
                
                // Bellsprout Line
                new Pokemon { Id = 69, Name = "Bellsprout", Type = "Grass/Poison", Generation = 1 },
                new Pokemon { Id = 70, Name = "Weepinbell", Type = "Grass/Poison", Generation = 1 },
                new Pokemon { Id = 71, Name = "Victreebel", Type = "Grass/Poison", Generation = 1 },
                
                // Tentacool Line
                new Pokemon { Id = 72, Name = "Tentacool", Type = "Water/Poison", Generation = 1 },
                new Pokemon { Id = 73, Name = "Tentacruel", Type = "Water/Poison", Generation = 1 },
                
                // Geodude Line
                new Pokemon { Id = 74, Name = "Geodude", Type = "Rock/Ground", Generation = 1 },
                new Pokemon { Id = 75, Name = "Graveler", Type = "Rock/Ground", Generation = 1 },
                new Pokemon { Id = 76, Name = "Golem", Type = "Rock/Ground", Generation = 1 },
                
                // Ponyta Line
                new Pokemon { Id = 77, Name = "Ponyta", Type = "Fire", Generation = 1 },
                new Pokemon { Id = 78, Name = "Rapidash", Type = "Fire", Generation = 1 },
                
                // Slowpoke Line
                new Pokemon { Id = 79, Name = "Slowpoke", Type = "Water/Psychic", Generation = 1 },
                new Pokemon { Id = 80, Name = "Slowbro", Type = "Water/Psychic", Generation = 1 },
                
                // Magnemite Line
                new Pokemon { Id = 81, Name = "Magnemite", Type = "Electric/Steel", Generation = 1 },
                new Pokemon { Id = 82, Name = "Magneton", Type = "Electric/Steel", Generation = 1 },
                
                // Farfetch'd
                new Pokemon { Id = 83, Name = "Farfetch'd", Type = "Normal/Flying", Generation = 1 },
                
                // Doduo Line
                new Pokemon { Id = 84, Name = "Doduo", Type = "Normal/Flying", Generation = 1 },
                new Pokemon { Id = 85, Name = "Dodrio", Type = "Normal/Flying", Generation = 1 },
                
                // Seel Line
                new Pokemon { Id = 86, Name = "Seel", Type = "Water", Generation = 1 },
                new Pokemon { Id = 87, Name = "Dewgong", Type = "Water/Ice", Generation = 1 },
                
                // Grimer Line
                new Pokemon { Id = 88, Name = "Grimer", Type = "Poison", Generation = 1 },
                new Pokemon { Id = 89, Name = "Muk", Type = "Poison", Generation = 1 },
                
                // Shellder Line
                new Pokemon { Id = 90, Name = "Shellder", Type = "Water", Generation = 1 },
                new Pokemon { Id = 91, Name = "Cloyster", Type = "Water/Ice", Generation = 1 },
                
                // Gastly Line
                new Pokemon { Id = 92, Name = "Gastly", Type = "Ghost/Poison", Generation = 1 },
                new Pokemon { Id = 93, Name = "Haunter", Type = "Ghost/Poison", Generation = 1 },
                new Pokemon { Id = 94, Name = "Gengar", Type = "Ghost/Poison", Generation = 1 },
                
                // Onix
                new Pokemon { Id = 95, Name = "Onix", Type = "Rock/Ground", Generation = 1 },
                
                // Drowzee Line
                new Pokemon { Id = 96, Name = "Drowzee", Type = "Psychic", Generation = 1 },
                new Pokemon { Id = 97, Name = "Hypno", Type = "Psychic", Generation = 1 },
                
                // Krabby Line
                new Pokemon { Id = 98, Name = "Krabby", Type = "Water", Generation = 1 },
                new Pokemon { Id = 99, Name = "Kingler", Type = "Water", Generation = 1 },
                
                // Voltorb Line
                new Pokemon { Id = 100, Name = "Voltorb", Type = "Electric", Generation = 1 },
                new Pokemon { Id = 101, Name = "Electrode", Type = "Electric", Generation = 1 },
                
                // Exeggcute Line
                new Pokemon { Id = 102, Name = "Exeggcute", Type = "Grass/Psychic", Generation = 1 },
                new Pokemon { Id = 103, Name = "Exeggutor", Type = "Grass/Psychic", Generation = 1 },
                
                // Cubone Line
                new Pokemon { Id = 104, Name = "Cubone", Type = "Ground", Generation = 1 },
                new Pokemon { Id = 105, Name = "Marowak", Type = "Ground", Generation = 1 },
                
                // Hitmonlee/Hitmonchan
                new Pokemon { Id = 106, Name = "Hitmonlee", Type = "Fighting", Generation = 1 },
                new Pokemon { Id = 107, Name = "Hitmonchan", Type = "Fighting", Generation = 1 },
                
                // Lickitung
                new Pokemon { Id = 108, Name = "Lickitung", Type = "Normal", Generation = 1 },
                
                // Koffing Line
                new Pokemon { Id = 109, Name = "Koffing", Type = "Poison", Generation = 1 },
                new Pokemon { Id = 110, Name = "Weezing", Type = "Poison", Generation = 1 },
                
                // Rhyhorn Line
                new Pokemon { Id = 111, Name = "Rhyhorn", Type = "Ground/Rock", Generation = 1 },
                new Pokemon { Id = 112, Name = "Rhydon", Type = "Ground/Rock", Generation = 1 },
                
                // Chansey
                new Pokemon { Id = 113, Name = "Chansey", Type = "Normal", Generation = 1 },
                
                // Tangela
                new Pokemon { Id = 114, Name = "Tangela", Type = "Grass", Generation = 1 },
                
                // Kangaskhan
                new Pokemon { Id = 115, Name = "Kangaskhan", Type = "Normal", Generation = 1 },
                
                // Horsea Line
                new Pokemon { Id = 116, Name = "Horsea", Type = "Water", Generation = 1 },
                new Pokemon { Id = 117, Name = "Seadra", Type = "Water", Generation = 1 },
                
                // Goldeen Line
                new Pokemon { Id = 118, Name = "Goldeen", Type = "Water", Generation = 1 },
                new Pokemon { Id = 119, Name = "Seaking", Type = "Water", Generation = 1 },
                
                // Staryu Line
                new Pokemon { Id = 120, Name = "Staryu", Type = "Water", Generation = 1 },
                new Pokemon { Id = 121, Name = "Starmie", Type = "Water/Psychic", Generation = 1 },
                
                // Mr. Mime
                new Pokemon { Id = 122, Name = "Mr. Mime", Type = "Psychic/Fairy", Generation = 1 },
                
                // Scyther
                new Pokemon { Id = 123, Name = "Scyther", Type = "Bug/Flying", Generation = 1 },
                
                // Jynx
                new Pokemon { Id = 124, Name = "Jynx", Type = "Ice/Psychic", Generation = 1 },
                
                // Electabuzz
                new Pokemon { Id = 125, Name = "Electabuzz", Type = "Electric", Generation = 1 },
                
                // Magmar
                new Pokemon { Id = 126, Name = "Magmar", Type = "Fire", Generation = 1 },
                
                // Pinsir
                new Pokemon { Id = 127, Name = "Pinsir", Type = "Bug", Generation = 1 },
                
                // Tauros
                new Pokemon { Id = 128, Name = "Tauros", Type = "Normal", Generation = 1 },
                
                // Magikarp Line
                new Pokemon { Id = 129, Name = "Magikarp", Type = "Water", Generation = 1 },
                new Pokemon { Id = 130, Name = "Gyarados", Type = "Water/Flying", Generation = 1 },
                
                // Lapras
                new Pokemon { Id = 131, Name = "Lapras", Type = "Water/Ice", Generation = 1 },
                
                // Ditto
                new Pokemon { Id = 132, Name = "Ditto", Type = "Normal", Generation = 1 },
                
                // Eevee Line
                new Pokemon { Id = 133, Name = "Eevee", Type = "Normal", Generation = 1 },
                new Pokemon { Id = 134, Name = "Vaporeon", Type = "Water", Generation = 1 },
                new Pokemon { Id = 135, Name = "Jolteon", Type = "Electric", Generation = 1 },
                new Pokemon { Id = 136, Name = "Flareon", Type = "Fire", Generation = 1 },
                
                // Porygon
                new Pokemon { Id = 137, Name = "Porygon", Type = "Normal", Generation = 1 },
                
                // Omanyte Line
                new Pokemon { Id = 138, Name = "Omanyte", Type = "Rock/Water", Generation = 1 },
                new Pokemon { Id = 139, Name = "Omastar", Type = "Rock/Water", Generation = 1 },
                
                // Kabuto Line
                new Pokemon { Id = 140, Name = "Kabuto", Type = "Rock/Water", Generation = 1 },
                new Pokemon { Id = 141, Name = "Kabutops", Type = "Rock/Water", Generation = 1 },
                
                // Aerodactyl
                new Pokemon { Id = 142, Name = "Aerodactyl", Type = "Rock/Flying", Generation = 1 },
                
                // Snorlax
                new Pokemon { Id = 143, Name = "Snorlax", Type = "Normal", Generation = 1 },
                
                // Legendary Birds
                new Pokemon { Id = 144, Name = "Articuno", Type = "Ice/Flying", Generation = 1 },
                new Pokemon { Id = 145, Name = "Zapdos", Type = "Electric/Flying", Generation = 1 },
                new Pokemon { Id = 146, Name = "Moltres", Type = "Fire/Flying", Generation = 1 },
                
                // Dratini Line
                new Pokemon { Id = 147, Name = "Dratini", Type = "Dragon", Generation = 1 },
                new Pokemon { Id = 148, Name = "Dragonair", Type = "Dragon", Generation = 1 },
                new Pokemon { Id = 149, Name = "Dragonite", Type = "Dragon/Flying", Generation = 1 },
                
                // Mewtwo
                new Pokemon { Id = 150, Name = "Mewtwo", Type = "Psychic", Generation = 1 },
                
                // Mew
                new Pokemon { Id = 151, Name = "Mew", Type = "Psychic", Generation = 1 },
                
                // ===== GENERATION 2 (JOHTO) =====
                // Chikorita Line
                new Pokemon { Id = 152, Name = "Chikorita", Type = "Grass", Generation = 2 },
                new Pokemon { Id = 153, Name = "Bayleef", Type = "Grass", Generation = 2 },
                new Pokemon { Id = 154, Name = "Meganium", Type = "Grass", Generation = 2 },
                
                // Cyndaquil Line
                new Pokemon { Id = 155, Name = "Cyndaquil", Type = "Fire", Generation = 2 },
                new Pokemon { Id = 156, Name = "Quilava", Type = "Fire", Generation = 2 },
                new Pokemon { Id = 157, Name = "Typhlosion", Type = "Fire", Generation = 2 },
                
                // Totodile Line
                new Pokemon { Id = 158, Name = "Totodile", Type = "Water", Generation = 2 },
                new Pokemon { Id = 159, Name = "Croconaw", Type = "Water", Generation = 2 },
                new Pokemon { Id = 160, Name = "Feraligatr", Type = "Water", Generation = 2 },
                
                // Sentret Line
                new Pokemon { Id = 161, Name = "Sentret", Type = "Normal", Generation = 2 },
                new Pokemon { Id = 162, Name = "Furret", Type = "Normal", Generation = 2 },
                
                // Hoothoot Line
                new Pokemon { Id = 163, Name = "Hoothoot", Type = "Normal/Flying", Generation = 2 },
                new Pokemon { Id = 164, Name = "Noctowl", Type = "Normal/Flying", Generation = 2 },
                
                // Ledyba Line
                new Pokemon { Id = 165, Name = "Ledyba", Type = "Bug/Flying", Generation = 2 },
                new Pokemon { Id = 166, Name = "Ledian", Type = "Bug/Flying", Generation = 2 },
                
                // Spinarak Line
                new Pokemon { Id = 167, Name = "Spinarak", Type = "Bug/Poison", Generation = 2 },
                new Pokemon { Id = 168, Name = "Ariados", Type = "Bug/Poison", Generation = 2 },
                
                // Crobat (Golbat evolution)
                new Pokemon { Id = 169, Name = "Crobat", Type = "Poison/Flying", Generation = 2 },
                
                // Chinchou Line
                new Pokemon { Id = 170, Name = "Chinchou", Type = "Water/Electric", Generation = 2 },
                new Pokemon { Id = 171, Name = "Lanturn", Type = "Water/Electric", Generation = 2 },
                
                // Pichu
                new Pokemon { Id = 172, Name = "Pichu", Type = "Electric", Generation = 2 },
                
                // Cleffa
                new Pokemon { Id = 173, Name = "Cleffa", Type = "Fairy", Generation = 2 },
                
                // Igglybuff
                new Pokemon { Id = 174, Name = "Igglybuff", Type = "Normal/Fairy", Generation = 2 },
                
                // Togepi Line
                new Pokemon { Id = 175, Name = "Togepi", Type = "Fairy", Generation = 2 },
                new Pokemon { Id = 176, Name = "Togetic", Type = "Fairy/Flying", Generation = 2 },
                
                // Natu Line
                new Pokemon { Id = 177, Name = "Natu", Type = "Psychic/Flying", Generation = 2 },
                new Pokemon { Id = 178, Name = "Xatu", Type = "Psychic/Flying", Generation = 2 },
                
                // Mareep Line
                new Pokemon { Id = 179, Name = "Mareep", Type = "Electric", Generation = 2 },
                new Pokemon { Id = 180, Name = "Flaaffy", Type = "Electric", Generation = 2 },
                new Pokemon { Id = 181, Name = "Ampharos", Type = "Electric", Generation = 2 },
                
                // Bellossom (Gloom evolution)
                new Pokemon { Id = 182, Name = "Bellossom", Type = "Grass", Generation = 2 },
                
                // Marill Line
                new Pokemon { Id = 183, Name = "Marill", Type = "Water/Fairy", Generation = 2 },
                new Pokemon { Id = 184, Name = "Azumarill", Type = "Water/Fairy", Generation = 2 },
                
                // Sudowoodo
                new Pokemon { Id = 185, Name = "Sudowoodo", Type = "Rock", Generation = 2 },
                
                // Politoed (Poliwhirl evolution)
                new Pokemon { Id = 186, Name = "Politoed", Type = "Water", Generation = 2 },
                
                // Hoppip Line
                new Pokemon { Id = 187, Name = "Hoppip", Type = "Grass/Flying", Generation = 2 },
                new Pokemon { Id = 188, Name = "Skiploom", Type = "Grass/Flying", Generation = 2 },
                new Pokemon { Id = 189, Name = "Jumpluff", Type = "Grass/Flying", Generation = 2 },
                
                // Aipom
                new Pokemon { Id = 190, Name = "Aipom", Type = "Normal", Generation = 2 },
                
                // Sunkern Line
                new Pokemon { Id = 191, Name = "Sunkern", Type = "Grass", Generation = 2 },
                new Pokemon { Id = 192, Name = "Sunflora", Type = "Grass", Generation = 2 },
                
                // Yanma
                new Pokemon { Id = 193, Name = "Yanma", Type = "Bug/Flying", Generation = 2 },
                
                // Wooper Line
                new Pokemon { Id = 194, Name = "Wooper", Type = "Water/Ground", Generation = 2 },
                new Pokemon { Id = 195, Name = "Quagsire", Type = "Water/Ground", Generation = 2 },
                
                // Espeon
                new Pokemon { Id = 196, Name = "Espeon", Type = "Psychic", Generation = 2 },
                
                // Umbreon
                new Pokemon { Id = 197, Name = "Umbreon", Type = "Dark", Generation = 2 },
                
                // Murkrow
                new Pokemon { Id = 198, Name = "Murkrow", Type = "Dark/Flying", Generation = 2 },
                
                // Slowking (Slowpoke evolution)
                new Pokemon { Id = 199, Name = "Slowking", Type = "Water/Psychic", Generation = 2 },
                
                // Misdreavus
                new Pokemon { Id = 200, Name = "Misdreavus", Type = "Ghost", Generation = 2 },
                
                // Unown
                new Pokemon { Id = 201, Name = "Unown", Type = "Psychic", Generation = 2 },
                
                // Wobbuffet
                new Pokemon { Id = 202, Name = "Wobbuffet", Type = "Psychic", Generation = 2 },
                
                // Girafarig
                new Pokemon { Id = 203, Name = "Girafarig", Type = "Normal/Psychic", Generation = 2 },
                
                // Pineco Line
                new Pokemon { Id = 204, Name = "Pineco", Type = "Bug", Generation = 2 },
                new Pokemon { Id = 205, Name = "Forretress", Type = "Bug/Steel", Generation = 2 },
                
                // Dunsparce
                new Pokemon { Id = 206, Name = "Dunsparce", Type = "Normal", Generation = 2 },
                
                // Gligar
                new Pokemon { Id = 207, Name = "Gligar", Type = "Ground/Flying", Generation = 2 },
                
                // Steelix (Onix evolution)
                new Pokemon { Id = 208, Name = "Steelix", Type = "Steel/Ground", Generation = 2 },
                
                // Snubbull Line
                new Pokemon { Id = 209, Name = "Snubbull", Type = "Fairy", Generation = 2 },
                new Pokemon { Id = 210, Name = "Granbull", Type = "Fairy", Generation = 2 },
                
                // Qwilfish
                new Pokemon { Id = 211, Name = "Qwilfish", Type = "Water/Poison", Generation = 2 },
                
                // Scizor (Scyther evolution)
                new Pokemon { Id = 212, Name = "Scizor", Type = "Bug/Steel", Generation = 2 },
                
                // Shuckle
                new Pokemon { Id = 213, Name = "Shuckle", Type = "Bug/Rock", Generation = 2 },
                
                // Heracross
                new Pokemon { Id = 214, Name = "Heracross", Type = "Bug/Fighting", Generation = 2 },
                
                // Sneasel
                new Pokemon { Id = 215, Name = "Sneasel", Type = "Dark/Ice", Generation = 2 },
                
                // Teddiursa Line
                new Pokemon { Id = 216, Name = "Teddiursa", Type = "Normal", Generation = 2 },
                new Pokemon { Id = 217, Name = "Ursaring", Type = "Normal", Generation = 2 },
                
                // Slugma Line
                new Pokemon { Id = 218, Name = "Slugma", Type = "Fire", Generation = 2 },
                new Pokemon { Id = 219, Name = "Magcargo", Type = "Fire/Rock", Generation = 2 },
                
                // Swinub Line
                new Pokemon { Id = 220, Name = "Swinub", Type = "Ice/Ground", Generation = 2 },
                new Pokemon { Id = 221, Name = "Piloswine", Type = "Ice/Ground", Generation = 2 },
                
                // Corsola
                new Pokemon { Id = 222, Name = "Corsola", Type = "Water/Rock", Generation = 2 },
                
                // Remoraid Line
                new Pokemon { Id = 223, Name = "Remoraid", Type = "Water", Generation = 2 },
                new Pokemon { Id = 224, Name = "Octillery", Type = "Water", Generation = 2 },
                
                // Delibird
                new Pokemon { Id = 225, Name = "Delibird", Type = "Ice/Flying", Generation = 2 },
                
                // Mantine
                new Pokemon { Id = 226, Name = "Mantine", Type = "Water/Flying", Generation = 2 },
                
                // Skarmory
                new Pokemon { Id = 227, Name = "Skarmory", Type = "Steel/Flying", Generation = 2 },
                
                // Houndour Line
                new Pokemon { Id = 228, Name = "Houndour", Type = "Dark/Fire", Generation = 2 },
                new Pokemon { Id = 229, Name = "Houndoom", Type = "Dark/Fire", Generation = 2 },
                
                // Kingdra (Seadra evolution)
                new Pokemon { Id = 230, Name = "Kingdra", Type = "Water/Dragon", Generation = 2 },
                
                // Phanpy Line
                new Pokemon { Id = 231, Name = "Phanpy", Type = "Ground", Generation = 2 },
                new Pokemon { Id = 232, Name = "Donphan", Type = "Ground", Generation = 2 },
                
                // Porygon2 (Porygon evolution)
                new Pokemon { Id = 233, Name = "Porygon2", Type = "Normal", Generation = 2 },
                
                // Stantler
                new Pokemon { Id = 234, Name = "Stantler", Type = "Normal", Generation = 2 },
                
                // Smeargle
                new Pokemon { Id = 235, Name = "Smeargle", Type = "Normal", Generation = 2 },
                
                // Tyrogue Line
                new Pokemon { Id = 236, Name = "Tyrogue", Type = "Fighting", Generation = 2 },
                new Pokemon { Id = 237, Name = "Hitmontop", Type = "Fighting", Generation = 2 },
                
                // Smoochum
                new Pokemon { Id = 238, Name = "Smoochum", Type = "Ice/Psychic", Generation = 2 },
                
                // Elekid
                new Pokemon { Id = 239, Name = "Elekid", Type = "Electric", Generation = 2 },
                
                // Magby
                new Pokemon { Id = 240, Name = "Magby", Type = "Fire", Generation = 2 },
                
                // Miltank
                new Pokemon { Id = 241, Name = "Miltank", Type = "Normal", Generation = 2 },
                
                // Blissey (Chansey evolution)
                new Pokemon { Id = 242, Name = "Blissey", Type = "Normal", Generation = 2 },
                
                // Legendary Beasts
                new Pokemon { Id = 243, Name = "Raikou", Type = "Electric", Generation = 2 },
                new Pokemon { Id = 244, Name = "Entei", Type = "Fire", Generation = 2 },
                new Pokemon { Id = 245, Name = "Suicune", Type = "Water", Generation = 2 },
                
                // Larvitar Line
                new Pokemon { Id = 246, Name = "Larvitar", Type = "Rock/Ground", Generation = 2 },
                new Pokemon { Id = 247, Name = "Pupitar", Type = "Rock/Ground", Generation = 2 },
                new Pokemon { Id = 248, Name = "Tyranitar", Type = "Rock/Dark", Generation = 2 },
                
                // Lugia
                new Pokemon { Id = 249, Name = "Lugia", Type = "Psychic/Flying", Generation = 2 },
                
                // Ho-Oh
                new Pokemon { Id = 250, Name = "Ho-Oh", Type = "Fire/Flying", Generation = 2 },
                
                // Celebi
                new Pokemon { Id = 251, Name = "Celebi", Type = "Psychic/Grass", Generation = 2 }
            };
        }

        private static void SetEvolutionRelationships(PokemonContext context)
        {
            // ===== GENERATION 1 =====
            // Bulbasaur Line
            SetEvolutionChain(context, 1, 2, 3);

            // Charmander Line
            SetEvolutionChain(context, 4, 5, 6);

            // Squirtle Line
            SetEvolutionChain(context, 7, 8, 9);

            // Caterpie Line
            SetEvolutionChain(context, 10, 11, 12);

            // Weedle Line
            SetEvolutionChain(context, 13, 14, 15);

            // Pidgey Line
            SetEvolutionChain(context, 16, 17, 18);

            // Rattata Line
            SetEvolutionChain(context, 19, 20);

            // Spearow Line
            SetEvolutionChain(context, 21, 22);

            // Ekans Line
            SetEvolutionChain(context, 23, 24);

            // Pikachu Line
            SetEvolutionChain(context, 25, 26);

            // Sandshrew Line
            SetEvolutionChain(context, 27, 28);

            // Nidoran♀ Line
            SetEvolutionChain(context, 29, 30, 31);

            // Nidoran♂ Line
            SetEvolutionChain(context, 32, 33, 34);

            // Clefairy Line
            SetEvolutionChain(context, 35, 36);

            // Vulpix Line
            SetEvolutionChain(context, 37, 38);

            // Jigglypuff Line
            SetEvolutionChain(context, 39, 40);

            // Zubat Line
            SetEvolutionChain(context, 41, 42);

            // Oddish Line
            SetEvolutionChain(context, 43, 44, 45);

            // Paras Line
            SetEvolutionChain(context, 46, 47);

            // Venonat Line
            SetEvolutionChain(context, 48, 49);

            // Diglett Line
            SetEvolutionChain(context, 50, 51);

            // Meowth Line
            SetEvolutionChain(context, 52, 53);

            // Psyduck Line
            SetEvolutionChain(context, 54, 55);

            // Mankey Line
            SetEvolutionChain(context, 56, 57);

            // Growlithe Line
            SetEvolutionChain(context, 58, 59);

            // Poliwag Line
            SetEvolutionChain(context, 60, 61, 62);

            // Abra Line
            SetEvolutionChain(context, 63, 64, 65);

            // Machop Line
            SetEvolutionChain(context, 66, 67, 68);

            // Bellsprout Line
            SetEvolutionChain(context, 69, 70, 71);

            // Tentacool Line
            SetEvolutionChain(context, 72, 73);

            // Geodude Line
            SetEvolutionChain(context, 74, 75, 76);

            // Ponyta Line
            SetEvolutionChain(context, 77, 78);

            // Slowpoke Line
            SetEvolutionChain(context, 79, 80);

            // Magnemite Line
            SetEvolutionChain(context, 81, 82);

            // Doduo Line
            SetEvolutionChain(context, 84, 85);

            // Seel Line
            SetEvolutionChain(context, 86, 87);

            // Grimer Line
            SetEvolutionChain(context, 88, 89);

            // Shellder Line
            SetEvolutionChain(context, 90, 91);

            // Gastly Line
            SetEvolutionChain(context, 92, 93, 94);

            // Drowzee Line
            SetEvolutionChain(context, 96, 97);

            // Krabby Line
            SetEvolutionChain(context, 98, 99);

            // Voltorb Line
            SetEvolutionChain(context, 100, 101);

            // Exeggcute Line
            SetEvolutionChain(context, 102, 103);

            // Cubone Line
            SetEvolutionChain(context, 104, 105);

            // Koffing Line
            SetEvolutionChain(context, 109, 110);

            // Rhyhorn Line
            SetEvolutionChain(context, 111, 112);

            // Horsea Line
            SetEvolutionChain(context, 116, 117);

            // Goldeen Line
            SetEvolutionChain(context, 118, 119);

            // Staryu Line
            SetEvolutionChain(context, 120, 121);

            // Magikarp Line
            SetEvolutionChain(context, 129, 130);

            // Eevee Evolutions
            var eevee = context.Pokemons.Find(133);
            var vaporeon = context.Pokemons.Find(134);
            var jolteon = context.Pokemons.Find(135);
            var flareon = context.Pokemons.Find(136);

            vaporeon.BaseEvolutionId = 133;
            jolteon.BaseEvolutionId = 133;
            flareon.BaseEvolutionId = 133;

            // Omanyte Line
            SetEvolutionChain(context, 138, 139);

            // Kabuto Line
            SetEvolutionChain(context, 140, 141);

            // Dratini Line
            SetEvolutionChain(context, 147, 148, 149);

            // ===== GENERATION 2 =====
            // Chikorita Line
            SetEvolutionChain(context, 152, 153, 154);

            // Cyndaquil Line
            SetEvolutionChain(context, 155, 156, 157);

            // Totodile Line
            SetEvolutionChain(context, 158, 159, 160);

            // Sentret Line
            SetEvolutionChain(context, 161, 162);

            // Hoothoot Line
            SetEvolutionChain(context, 163, 164);

            // Ledyba Line
            SetEvolutionChain(context, 165, 166);

            // Spinarak Line
            SetEvolutionChain(context, 167, 168);

            // Crobat (Golbat evolution)
            var golbat = context.Pokemons.Find(42);
            var crobat = context.Pokemons.Find(169);
            golbat.NextEvolutionId = 169;
            crobat.BaseEvolutionId = 41; // Base is Zubat

            // Chinchou Line
            SetEvolutionChain(context, 170, 171);

            // Pichu Line
            SetEvolutionChain(context, 172, 25); // Pichu -> Pikachu

            // Cleffa Line
            SetEvolutionChain(context, 173, 35); // Cleffa -> Clefairy

            // Igglybuff Line
            SetEvolutionChain(context, 174, 39); // Igglybuff -> Jigglypuff

            // Togepi Line
            SetEvolutionChain(context, 175, 176);

            // Natu Line
            SetEvolutionChain(context, 177, 178);

            // Mareep Line
            SetEvolutionChain(context, 179, 180, 181);

            // Bellossom (Gloom evolution)
            var gloom = context.Pokemons.Find(44);
            var bellossom = context.Pokemons.Find(182);
            gloom.NextEvolutionId = 182; // Alternate evolution
            bellossom.BaseEvolutionId = 43; // Base is Oddish

            // Marill Line
            SetEvolutionChain(context, 183, 184);

            // Hoppip Line
            SetEvolutionChain(context, 187, 188, 189);

            // Sunkern Line
            SetEvolutionChain(context, 191, 192);

            // Wooper Line
            SetEvolutionChain(context, 194, 195);

            // Pineco Line
            SetEvolutionChain(context, 204, 205);

            // Snubbull Line
            SetEvolutionChain(context, 209, 210);

            // Teddiursa Line
            SetEvolutionChain(context, 216, 217);

            // Slugma Line
            SetEvolutionChain(context, 218, 219);

            // Swinub Line
            SetEvolutionChain(context, 220, 221);

            // Remoraid Line
            SetEvolutionChain(context, 223, 224);

            // Houndour Line
            SetEvolutionChain(context, 228, 229);

            // Phanpy Line
            SetEvolutionChain(context, 231, 232);

            // Larvitar Line
            SetEvolutionChain(context, 246, 247, 248);

            // New evolutions for Gen 1 Pokémon
            var poliwhirl = context.Pokemons.Find(61);
            var politoed = context.Pokemons.Find(186);
            poliwhirl.NextEvolutionId = 186; // Alternate evolution
            politoed.BaseEvolutionId = 60; // Base is Poliwag

            var slowpoke = context.Pokemons.Find(79);
            var slowking = context.Pokemons.Find(199);
            slowpoke.NextEvolutionId = 199; // Alternate evolution
            slowking.BaseEvolutionId = 79;

            var onix = context.Pokemons.Find(95);
            var steelix = context.Pokemons.Find(208);
            onix.NextEvolutionId = 208;
            steelix.BaseEvolutionId = 95;

            var scyther = context.Pokemons.Find(123);
            var scizor = context.Pokemons.Find(212);
            scyther.NextEvolutionId = 212;
            scizor.BaseEvolutionId = 123;

            var seadra = context.Pokemons.Find(117);
            var kingdra = context.Pokemons.Find(230);
            seadra.NextEvolutionId = 230;
            kingdra.BaseEvolutionId = 116; // Base is Horsea

            var porygon = context.Pokemons.Find(137);
            var porygon2 = context.Pokemons.Find(233);
            porygon.NextEvolutionId = 233;
            porygon2.BaseEvolutionId = 137;

            var chansey = context.Pokemons.Find(113);
            var blissey = context.Pokemons.Find(242);
            chansey.NextEvolutionId = 242;
            blissey.BaseEvolutionId = 113;

            // Eevee's new evolutions
            var espeon = context.Pokemons.Find(196);
            var umbreon = context.Pokemons.Find(197);
            espeon.BaseEvolutionId = 133;
            umbreon.BaseEvolutionId = 133;

            context.SaveChanges();
        }

        private static void SetEvolutionChain(PokemonContext context, int baseId, int middleId, int? finalId = null)
        {
            var baseForm = context.Pokemons.Find(baseId);
            var middleForm = context.Pokemons.Find(middleId);

            baseForm.NextEvolutionId = middleId;
            middleForm.BaseEvolutionId = baseId;

            if (finalId.HasValue)
            {
                var finalForm = context.Pokemons.Find(finalId.Value);
                middleForm.NextEvolutionId = finalId;
                finalForm.BaseEvolutionId = baseId;
            }
        }
    }
}