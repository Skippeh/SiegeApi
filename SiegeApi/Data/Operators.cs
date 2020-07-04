using SiegeApi.Models;
// ReSharper disable StringLiteralTypo

namespace SiegeApi.Data
{
    public static class Operators
    {
        public static readonly Operator[] Data =
        {
            new Operator
            {
                Id = "recruit-sas",
                Name = "recruitsas",
                ReadableName = "SAS Recruit",
                FullIndex = "1:1",
                Team = TeamType.Both
            },
            new Operator
            {
                Id = "recruit-fbi-swat",
                Name = "recruitfbi",
                ReadableName = "FBI Recruit",
                FullIndex = "1:2",
                Team = TeamType.Both
            },
            new Operator
            {
                Id = "recruit-gign",
                Name = "recruitgign",
                ReadableName = "GIGN Recruit",
                FullIndex = "1:3",
                Team = TeamType.Both
            },
            new Operator
            {
                Id = "recruit-spetsnaz",
                Name = "recruitspetsnaz",
                ReadableName = "Spetsnaz Recruit",
                FullIndex = "1:4",
                Team = TeamType.Both
            },
            new Operator
            {
                Id = "recruit-gsg9",
                Name = "recruitgsg9",
                ReadableName = "GSG9 Recruit",
                FullIndex = "1:5",
                Team = TeamType.Both
            },
            new Operator
            {
                Id = "smoke-sas",
                Name = "smoke",
                ReadableName = "Smoke",
                FullIndex = "2:1",
                Gadgets = new[] {"operatorpvp_smoke_poisongaskill"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "mute-sas",
                Name = "mute",
                ReadableName = "Mute",
                FullIndex = "3:1",
                Gadgets = new[] {"operatorpvp_mute_gadgetjammed"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "sledge-sas",
                Name = "sledge",
                ReadableName = "Sledge",
                FullIndex = "4:1",
                Gadgets = new[] {"operatorpvp_sledge_hammerhole"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "thatcher-sas",
                Name = "thatcher",
                ReadableName = "Thatcher",
                FullIndex = "5:1",
                Gadgets = new[] {"operatorpvp_thatcher_gadgetdestroywithemp"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "castle-fbi-swat",
                Name = "castle",
                ReadableName = "Castle",
                FullIndex = "2:2",
                Gadgets = new[] {"operatorpvp_castle_kevlarbarricadedeployed"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "ash-fbi-swat",
                Name = "ash",
                ReadableName = "Ash",
                FullIndex = "3:2",
                Gadgets = new[] {"operatorpvp_ash_bonfirewallbreached"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "pulse-fbi-swat",
                Name = "pulse",
                ReadableName = "Pulse",
                FullIndex = "4:2",
                Gadgets = new[] {"operatorpvp_pulse_heartbeatspot"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "thermite-fbi-swat",
                Name = "thermite",
                ReadableName = "Thermite",
                FullIndex = "5:2",
                Gadgets = new[] {"operatorpvp_thermite_reinforcementbreached"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "doc-gign",
                Name = "doc",
                ReadableName = "Doc",
                FullIndex = "2:3",
                Gadgets = new[] {"operatorpvp_doc_teammaterevive"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "rook-gign",
                Name = "rook",
                ReadableName = "Rook",
                FullIndex = "3:3",
                Gadgets = new[] {"operatorpvp_rook_armortakenteammate"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "twitch-gign",
                Name = "twitch",
                ReadableName = "Twitch",
                FullIndex = "4:3",
                Gadgets = new[] {"operatorpvp_twitch_gadgetdestroybyshockdrone"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "montagne-gign",
                Name = "montagne",
                ReadableName = "Montagne",
                FullIndex = "5:3",
                Gadgets = new[] {"operatorpvp_montagne_shieldblockdamage"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "glaz-spetsnaz",
                Name = "glaz",
                ReadableName = "Glaz",
                FullIndex = "2:4",
                Gadgets = new[] {"operatorpvp_glaz_sniperkill"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "fuze-spetsnaz",
                Name = "fuze",
                ReadableName = "Fuze",
                FullIndex = "3:4",
                Gadgets = new[] {"operatorpvp_fuze_clusterchargekill"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "kapkan-spetsnaz",
                Name = "kapkan",
                ReadableName = "Kapkan",
                FullIndex = "4:4",
                Gadgets = new[] {"operatorpvp_kapkan_boobytrapkill"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "tachanka-spetsnaz",
                Name = "tachanka",
                ReadableName = "Tachanka",
                FullIndex = "5:4",
                Gadgets = new[] {"operatorpvp_tachanka_turretkill"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "blitz-gsg-9",
                Name = "blitz",
                ReadableName = "Blitz",
                FullIndex = "2:5",
                Gadgets = new[] {"operatorpvp_blitz_flashedenemy"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "iq-gsg-9",
                Name = "iq",
                ReadableName = "IQ",
                FullIndex = "3:5",
                Gadgets = new[] {"operatorpvp_iq_gadgetspotbyef"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "jager-gsg-9",
                Name = "jager",
                ReadableName = "Jäger",
                FullIndex = "4:5",
                Gadgets = new[] {"operatorpvp_jager_gadgetdestroybycatcher"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "bandit-gsg-9",
                Name = "bandit",
                ReadableName = "Bandit",
                FullIndex = "5:5",
                Gadgets = new[] {"operatorpvp_bandit_batterykill"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "buck-jtf2",
                Name = "buck",
                ReadableName = "Buck",
                FullIndex = "2:6",
                Gadgets = new[] {"operatorpvp_buck_kill"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "frost-jtf2",
                Name = "frost",
                ReadableName = "Frost",
                FullIndex = "3:6",
                Gadgets = new[] {"operatorpvp_frost_dbno"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "blackbeard-navy-seal",
                Name = "blackbeard",
                ReadableName = "Blackbeard",
                FullIndex = "2:7",
                Gadgets = new[] {"operatorpvp_blackbeard_gunshieldblockdamage"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "valkyrie-navy-seal",
                Name = "valkyrie",
                ReadableName = "Valkyrie",
                FullIndex = "3:7",
                Gadgets = new[] {"operatorpvp_valkyrie_camdeployed"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "capitao-bope",
                Name = "capitao",
                ReadableName = "Capitão",
                FullIndex = "2:8",
                Gadgets = new[] {"operatorpvp_capitao_lethaldartkills"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "caveira-bope",
                Name = "caveira",
                ReadableName = "Caveira",
                FullIndex = "3:8",
                Gadgets = new[] {"operatorpvp_caveira_interrogations"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "hibana-sat",
                Name = "hibana",
                ReadableName = "Hibana",
                FullIndex = "2:9",
                Gadgets = new[] {"operatorpvp_hibana_detonate_projectile"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "echo-sat",
                Name = "echo",
                ReadableName = "Echo",
                FullIndex = "3:9",
                Gadgets = new[] {"operatorpvp_echo_enemy_sonicburst_affected"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "jackal-geo",
                Name = "jackal",
                ReadableName = "Jackal",
                FullIndex = "2:A",
                Gadgets = new[] {"operatorpvp_cazador_assist_kill"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "mira-geo",
                Name = "mira",
                ReadableName = "Mira",
                FullIndex = "3:A",
                Gadgets = new[] {"operatorpvp_black_mirror_gadget_deployed"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "ying-sat",
                Name = "ying",
                ReadableName = "Ying",
                FullIndex = "2:B",
                Gadgets = new[] {"operatorpvp_dazzler_gadget_detonate"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "lesion-sat",
                Name = "lesion",
                ReadableName = "Lesion",
                FullIndex = "3:B",
                Gadgets = new[] {"operatorpvp_caltrop_enemy_affected"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "ela-grom",
                Name = "ela",
                ReadableName = "Ela",
                FullIndex = "2:C",
                Gadgets = new[] {"operatorpvp_concussionmine_detonate"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "zofia-grom",
                Name = "zofia",
                ReadableName = "Zofia",
                FullIndex = "3:C",
                Gadgets = new[] {"operatorpvp_concussiongrenade_detonate"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "vigil-707th-smb",
                Name = "vigil",
                ReadableName = "Vigil",
                FullIndex = "3:D",
                Gadgets = new[] {"operatorpvp_attackerdrone_diminishedrealitymode"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "dokkaebi-707th-smb",
                Name = "dokkaebi",
                ReadableName = "Dokkaebi",
                FullIndex = "2:D",
                Gadgets = new[] {"disaplaceholder"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "Lion-gign",
                Name = "lion",
                ReadableName = "Lion",
                FullIndex = "3:E",
                Gadgets = new[] {"operatorpvp_tagger_tagdevice_spot"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "Finka-spetsnaz",
                Name = "finka",
                ReadableName = "Finka",
                FullIndex = "4:E",
                Gadgets = new[] {"operatorpvp_rush_adrenalinerush"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "Maestro-gis",
                Name = "maestro",
                ReadableName = "Maestro",
                FullIndex = "2:F",
                Gadgets = new[] {"operatorpvp_tagger_tagdevice_spot"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "Alibi-gis",
                Name = "alibi",
                ReadableName = "Alibi",
                FullIndex = "3:F",
                Gadgets = new[] {"operatorpvp_deceiver_revealedattackers"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "Nomad-gigr",
                Name = "nomad",
                ReadableName = "Nomad",
                FullIndex = "2:11",
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "Kaid-gis",
                Name = "Kaid",
                ReadableName = "Kaid",
                FullIndex = "3:11",
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "Clash-gsutr",
                Name = "clash",
                ReadableName = "Clash",
                FullIndex = "3:10",
                Gadgets = new[] {"operatorpvp_clash_sloweddown"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "Maverick-gsutr",
                Name = "maverick",
                ReadableName = "Maverick",
                FullIndex = "2:10",
                Gadgets = new[] {"operatorpvp_maverick_wallbreached"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "Gridlock-sasr",
                Name = "gridlock",
                ReadableName = "Gridlock",
                FullIndex = "3:12",
                Gadgets = new[] {"operatorpvp_gridlock_traxdeployed"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "Mozzie-sasr",
                Name = "mozzie",
                ReadableName = "Mozzie",
                FullIndex = "2:12",
                Gadgets = new[] {"operatorpvp_mozzie_droneshacked"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "nakk",
                Name = "nokk",
                ReadableName = "Nøkk",
                FullIndex = "2:13",
                Gadgets = new[] {"operatorpvp_Nokk_Cameras_Deceived"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "warden",
                Name = "warden",
                ReadableName = "Warden",
                FullIndex = "2:14",
                Gadgets = new[] {"operatorpvp_Warden_Kills_During_Ability"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "goyo",
                Name = "goyo",
                ReadableName = "Goyo",
                FullIndex = "2:15",
                Gadgets = new[] {"operatorpvp_goyo_volcandetonate"},
                Team = TeamType.Defender
            },
            new Operator
            {
                Id = "amaru",
                Name = "amaru",
                ReadableName = "Amaru",
                FullIndex = "2:16",
                Gadgets = new[] {"operatorpvp_amaru_distancereeled"},
                Team = TeamType.Attacker
            },
            new Operator
            {
                Id = "kali",
                Name = "Kali",
                ReadableName = "Kali",
                FullIndex = "2:17",
                Team = TeamType.Attacker,
                Gadgets = new[] {"operatorpvp_kali_gadgetdestroywithexplosivelance"}
            },
            new Operator
            {
                Id = "wamai",
                Name = "Wamai",
                ReadableName = "Wamai",
                FullIndex = "3:17",
                Team = TeamType.Defender,
                Gadgets = new[] {"operatorpvp_wamai_gadgetdestroybymagnet"}
            },
            new Operator
            {
                Id = "oryx",
                Name = "Oryx",
                ReadableName = "Oryx",
                FullIndex = "2:18",
                Team = TeamType.Defender,
                Gadgets = new[] {"operatorpvp_oryx_killsafterdash"}
            },
            new Operator
            {
                Id = "iana",
                Name = "Iana",
                ReadableName = "Iana",
                FullIndex = "2:19",
                Team = TeamType.Attacker,
                Gadgets = new[] {"operatorpvp_iana_killsafterreplicator"}
            },
            new Operator
            {
                Id = "ace",
                Name = "Ace",
                ReadableName = "Ace",
                FullIndex = "4:17",
                Team = TeamType.Attacker,
                Gadgets = new[] {"operatorpvp_ace_selmadetonate"}
            },
            new Operator
            {
                Id = "melusi",
                Name = "Melusi",
                ReadableName = "Melusi",
                FullIndex = "2:1A",
                Team = TeamType.Defender,
                Gadgets = new[] {"operatorpvp_melusi_sloweddown"}
            }
        };
    }
}