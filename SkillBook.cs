using ModShardLauncher;
using ModShardLauncher.Mods;
using System.Runtime.Versioning;
using UndertaleModLib.Models;
using static ModShardLauncher.Msl;

namespace FristMod
{
    [SupportedOSPlatform("windows")]
    public partial class MyFristMod : Mod
    {
        public static void AddSkillBook()
        {
            UndertaleGameObject o_inv_book_yuandaowu1 = Msl.AddObject(
                name: "o_inv_book_yuandaowu1",
                spriteName: "s_inv_bookC",
                parentName: "o_inv_treatise",
                isVisible: true,
                isAwake: true,
                isPersistent: true,
                collisionShapeFlags: CollisionShapeFlags.Circle
            );

            UndertaleGameObject o_inv_book_yuandaowu2 = Msl.AddObject(
                name: "o_inv_book_yuandaowu2",
                spriteName: "s_inv_bookK",
                parentName: "o_inv_treatise",
                isVisible: true,
                isAwake: true,
                isPersistent: true,
                collisionShapeFlags: CollisionShapeFlags.Circle
            );
            UndertaleGameObject o_inv_book_yuandaowu3 = Msl.AddObject(
                name: "o_inv_book_yuandaowu3",
                spriteName: "s_inv_bookL",
                parentName: "o_inv_treatise",
                isVisible: true,
                isAwake: true,
                isPersistent: true,
                collisionShapeFlags: CollisionShapeFlags.Circle
            );

            UndertaleGameObject o_loot_book_yuandaowu1 = Msl.AddObject(
                name: "o_loot_book_yuandaowu1",
                spriteName: "s_loot_BookC",
                parentName: "o_loot_treatise",
                isVisible: true,
                isAwake: true,
                isPersistent: false,
                collisionShapeFlags: CollisionShapeFlags.Circle
            );

            UndertaleGameObject o_loot_book_yuandaowu2 = Msl.AddObject(
                name: "o_loot_book_yuandaowu2",
                spriteName: "s_loot_BookK",
                parentName: "o_loot_treatise",
                isVisible: true,
                isAwake: true,
                isPersistent: false,
                collisionShapeFlags: CollisionShapeFlags.Circle
            );
            UndertaleGameObject o_loot_book_yuandaowu3 = Msl.AddObject(
                name: "o_loot_book_yuandaowu3",
                spriteName: "s_loot_BookL",
                parentName: "o_loot_treatise",
                isVisible: true,
                isAwake: true,
                isPersistent: false,
                collisionShapeFlags: CollisionShapeFlags.Circle
            );
            o_inv_book_yuandaowu1.ApplyEvent(
                new MslEvent(eventType: EventType.Create, subtype: 0, code: @"
                    event_inherited()
                    gain_xp = 50
                    skills_array = global.yuandaowu_tier1
                ")
            );

            o_inv_book_yuandaowu2.ApplyEvent(
                new MslEvent(eventType: EventType.Create, subtype: 0, code: @"
                    event_inherited()
                    gain_xp = 50
                    skills_array = global.yuandaowu_tier2
                ")
            );
            o_inv_book_yuandaowu3.ApplyEvent(
                new MslEvent(eventType: EventType.Create, subtype: 0, code: @"
                    event_inherited()
                    gain_xp = 50
                    skills_array = global.yuandaowu_tier3
                ")
            );
            o_loot_book_yuandaowu1.ApplyEvent(
                new MslEvent(eventType: EventType.Create, subtype: 0, code: @"
                    event_inherited()
                    inv_object = o_inv_book_yuandaowu1
                    number = 0
                ")
            );

            o_loot_book_yuandaowu2.ApplyEvent(
                new MslEvent(eventType: EventType.Create, subtype: 0, code: @"
                    event_inherited()
                    inv_object = o_inv_book_yuandaowu2
                    number = 0
                ")
            );
            o_loot_book_yuandaowu3.ApplyEvent(
                new MslEvent(eventType: EventType.Create, subtype: 0, code: @"
                    event_inherited()
                    inv_object = o_inv_book_yuandaowu3
                    number = 0
                ")
            );
            Msl.InjectTableItemStats(
                id: "book_yuandaowu1",
                Price: 250,
                EffPrice: 50,
                Material: Msl.ItemStatsMaterial.paper,
                tier: Msl.ItemStatsTier.Tier1,
                Subcat: Msl.ItemStatsSubcategory.treatise,
                Weight: Msl.ItemStatsWeight.Light,
                tags: Msl.ItemStatsTags.special
            );

            Msl.InjectTableItemStats(
                id: "book_yuandaowu2",
                Price: 1200,
                EffPrice: 250,
                Material: Msl.ItemStatsMaterial.paper,
                tier: Msl.ItemStatsTier.Tier2,
                Subcat: Msl.ItemStatsSubcategory.treatise,
                Weight: Msl.ItemStatsWeight.Light,
                tags: Msl.ItemStatsTags.special
            );
            Msl.InjectTableItemStats(
                id: "book_yuandaowu3",
                Price: 2500,
                EffPrice: 500,
                Material: Msl.ItemStatsMaterial.paper,
                tier: Msl.ItemStatsTier.Tier3,
                Subcat: Msl.ItemStatsSubcategory.treatise,
                Weight: Msl.ItemStatsWeight.Light,
                tags: Msl.ItemStatsTags.special
            );
            Msl.InjectTableBooksLocalization(
                new LocalizationBook(
                    id: "book_yuandaowu1",
                    name: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "Yuan Dao·Wu I" },
                        { ModLanguage.Chinese, "元道武典·卷一" }
                    },
                    content: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, string.Join("##",
                            "（ . . . ）",
                            "In my wanderings across the continent of Aldor, I chanced upon ruins whispered to be left by travelers from the distant East. Within a crumbled stone chamber, I found not gold or enchanted artifacts, but scrolls of profound simplicity. They spoke not of manipulating Aether or channeling elemental fury, but of an inner power cultivated through breath, posture, and disciplined motion—a martial art they called ‘Yuan Dao Wu’, the Way of the Primal Fist.",
                            "（ . . . ）",
                            "Fascinated, I abandoned my steel swords for a time. I began the arduous practice, seeking to understand this power that flowed from within rather than being drawn from without. The initial forms were deceptively simple: a focused strike that could shatter stone , a fluid step that harmonized attack and defense, and a meditative state that brought perfect equilibrium to the practitioner's being.",
                            "（ . . . ）",
                            "This ‘Inner Balance’ is the cornerstone. It is the calm center from which all techniques erupt. Without it, the fist is but a clumsy weapon; with it, the body becomes an unstoppable force."
                        )},
                        { ModLanguage.Chinese, string.Join("##",
                            "（ . . . ）",
                            "在奥尔多大陆游历时，我偶然发现了一处遗迹，传闻是遥远的东方旅者所留。在一间坍塌的石室中，我找到的并非黄金或魔法造物，而是几卷至简至深的卷轴。其中所述，并非操控以太或引导元素之力，而是一种通过呼吸、架势与规整的动律所锤炼的内在力量——他们称之为‘元道·武’，即‘太初之拳’的道路。",
                            "（ . . . ）",
                            "我深深着迷，暂时搁置了钢剑。我开始进行艰苦的修炼，试图理解这种源于内在而非取于外界的力量。最初的招式看似简单，实则精深：一记足以崩裂岩石的专注拳击，一种调和攻防的流步，以及一种能让修习者身心臻至完美平衡的冥想状态。",
                            "（ . . . ）",
                            "这‘内在平衡’乃是基石。它是所有技法得以迸发的宁静核心。无此平衡，拳仅是笨拙的武器；得此平衡，肉身便可化为无可阻挡的洪流。"
                        )}
                    },
                    midText: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "\"The First Steps on the Path of Inner Power\"##~gr~Allows you to learn the following Yuan Dao Wu abilities:~/~##~lg~SmashFist~/~#~lg~YinYangStrike~/~#~lg~Inner Balance~/~##Reading this book grants some ~y~Experience~/~." },
                        { ModLanguage.Chinese, "《内在力量之道·初阶》##~gr~可以学习以下元道·武能力：~/~##~lg~崩拳~/~#~lg~阴阳突~/~#~lg~内在平衡~/~##阅读本书可以获得一定的~y~经验~/~。" }
                    },
                    description: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "The first volume of a martial arts manual, detailing the foundational principles and techniques of a mysterious Eastern fighting style that relies on inner power rather than weapons." },
                        { ModLanguage.Chinese, "这是一本武术典籍的第一卷，详细记载了一种不依赖武器、凭借内在力量的神秘东方武学的基础原理与入门技法。它描述了修炼者杰隆·莫吕如何发现并开始修习此道。" }
                    },
                    type: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "Transcribed by Jerome Moreau" },
                        { ModLanguage.Chinese, "录于东方武道游历者" }
                    }
                ),
                new LocalizationBook(
                    id: "book_yuandaowu2", // 对应第二层，延续你原有命名逻辑
                    name: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "Yuan Dao·Wu II" },
                        { ModLanguage.Chinese, "元道武典·卷二" }
                    },
                    content: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, string.Join("##",
                            "（ . . . ）",
                            "Crossing the mist-shrouded mountains of Aldor, I chanced upon a hidden valley where elders of an Eastern martial tradition dwelled. They called their art \"Yuan Dao·Wu\"—a path of unarmed combat that harnessed the inner breath, or \"Qi\", rather than blades or bows.",
                            "（ . . . ）",
                            "After proving my resolve through days of meditation and discipline, they taught me the second tier of their sacred techniques: Circulating Inner Breath to unify body and mind, the Formless Stance that adapts to any attack, and the Phoenix Tail Grab that redirects an opponent’s force against them.",
                            "（ . . . ）",
                            "Unlike the brute strength of Aldor’s warriors, Yuan Dao·Wu focuses on harmony with one’s inner energy. Circulating Inner Breath (Nei Xi Zhou Tian) lets Qi flow through every meridian, banishing fatigue and sharpening reflexes. The Formless Stance (Wu Ji Shi) discards rigid forms, turning defense into offense in an instant.",
                            "（ . . . ）",
                            "The Phoenix Tail Grab (Lan Feng Wei) is the pinnacle of redirection—catching an enemy’s strike and twisting their momentum to throw them off balance, leaving them vulnerable to counterattacks. These skills are not just for combat, but for mastering the self.",
                            "（ . . . ）",
                            "I recorded these teachings carefully, for they are a gift to any who seek to defend themselves without weapons. The valley’s elders warned that mastery comes not from haste, but from aligning breath, mind, and movement as one."
                        ) },
                        { ModLanguage.Chinese, string.Join("##",
                            "（ . . . ）",
                            "穿越奥尔多大陆云雾缭绕的群山，我偶然踏入一处隐秘山谷，那里隐居着东方武道传承的长者。他们称其武学为「元道·武」——一条不依赖兵刃弓矢，只凭双拳调动体内「气」的徒手格斗之路。",
                            "（ . . . ）",
                            "历经数日禅定与苦修证明心志后，他们传授了我这门圣典武学的第二层技艺：以「内息周天」调和身心，以「无极式」应万变攻势，以「揽凤尾」借力打力反制对手。",
                            "（ . . . ）",
                            "与奥尔多战士崇尚的蛮力不同，元道·武讲求与自身内气的调和。内息周天能让气脉贯通周身经络，驱散疲态、锐化反应；无极式摒弃僵化招式，于瞬息间化守为攻，无迹可寻。",
                            "（ . . . ）",
                            "揽凤尾更是卸力巧劲的极致——接住敌人攻势的刹那，借其劲力扭转方向，令对手重心失衡，转瞬便露出破绽。这些技法不止用于搏杀，更是修行自我、掌控身心的法门。",
                            "（ . . . ）",
                            "我将这些教诲详录于此，愿这份无需兵刃即可御敌的智慧能惠及后人。山谷长者告诫：欲臻化境，非求速成，唯使呼吸、心神、动作融为一体，方得元道真意。"
                        )}
                    },
                    midText: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "\"The Path of Inner Breath\"##~gr~Allows you to learn the following Yuan Dao·Wu abilities:~/~##~lg~Microcosmic Orbit~/~#~lg~Wuji Stance~/~#~lg~Phoenix Tail Takedown~/~##Reading this book grants some ~y~Experience~/~." },
                        { ModLanguage.Chinese, "《内息通玄篇》##~gr~可以学习若干元道·武能力：~/~##~lg~内息周天~/~#~lg~无极式~/~#~lg~揽凤尾~/~##阅读本书可以获得一定的~y~经验~/~。" }
                    },
                    description: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "A book recording the second tier of Yuan Dao·Wu, an Eastern martial art that masters unarmed combat through inner breath control and formless adaptability." },
                        { ModLanguage.Chinese, "这是一本武术典籍的第二卷，这门源自东方的神秘武术摒弃兵刃，以调控内息、变幻无方的招式制敌，核心在于身心合一、借力打力。" }
                    },
                    type: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "Recorded by a Wanderer of Eastern Martial Arts" },
                        { ModLanguage.Chinese, "录于东方武道游历者" }
                    }
                ),
                new LocalizationBook(
                    id: "book_yuandaowu3",
                    name: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "Yuan Dao·Wu III" },
                        { ModLanguage.Chinese, "元道武典·卷三" }
                    },
                    content: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, string.Join("##",
                            "（ . . . ）",
                            "After mastering the second tier of Yuan Dao·Wu, I ventured deeper into Aldor’s forbidden forests, seeking to unlock the art’s ultimate potential. There, I encountered a lone martial sage who had spent decades merging Eastern Qi cultivation with the continent’s innate Aether, achieving a realm beyond mere technique.",
                            "（ . . . ）",
                            "He revealed that the highest form of Yuan Dao·Wu lies not in rigid moves, but in the free flow of inner energy—turning the body into a vessel of unstoppable force. Under his guidance, I awakened two pinnacle skills: Cloud-Sweeping Palm, which channels Qi into wide-ranging strikes that dispel crowds, and Qi Pervading the Body, which saturates every muscle with condensed energy, turning defense into impenetrable resolve.",
                            "（ . . . ）",
                            "Cloud-Sweeping Palm is no ordinary strike—each movement stirs the surrounding Aether, amplifying Qi to sweep through enemies like a tempest, yet leaving allies unharmed. Qi Pervading the Body transcends physical endurance; when activated, even the fiercest blows barely stagger, for the energy flowing through meridians turns impact into nourishment for further combat.",
                            "（ . . . ）",
                            "The sage taught me that true mastery is not dominating others, but harmonizing with the energy of the world. These final techniques of Yuan Dao·Wu are not weapons of conquest, but tools to protect what matters—proving that bare hands, guided by resolve and Qi, can stand against any blade or spell.",
                            "（ . . . ）",
                            "I write this last note as a testament to the journey. Yuan Dao·Wu is more than a martial art; it is a way of life. May those who find these words embrace the balance of strength and humility, and walk the path of inner power with courage."
                        ) },
                        { ModLanguage.Chinese, string.Join("##",
                            "（ . . . ）",
                            "悟透元道·武第二层奥义后，我深入奥尔多大陆的禁地森林，欲探寻这门武学的终极境界。在那里，我遇见一位独居的武道圣人——他耗费数十载光阴，将东方炼气之法与这片大陆的以太能量相融，臻至「技近乎道」的境地。",
                            "（ . . . ）",
                            "他告诉我，元道·武的至高境界，不在于招式的刚猛，而在于内气的圆融自在——让身躯成为承载无穷力量的容器。在他的点拨下，我觉醒了两门巅峰技艺：「排云掌」，以气御劲、大范围横扫千军；「气贯周身」，凝气于五脏六腑、筋骨脉络，化防御为无坚不摧的壁垒。",
                            "（ . . . ）",
                            "排云掌绝非寻常掌法——每一次挥击都牵动周遭以太，让内气如狂风骤雨般席卷敌阵，却能精准避开友军，不伤分毫。气贯周身则超越了肉体的极限：运转之时，即便遭遇雷霆重击也巍然不动，流经经络的内气会将冲击力转化为续航之力，支撑着战斗到最后一刻。",
                            "（ . . . ）",
                            "圣人言，真正的强者并非征服他人，而是与天地能量共生。元道·武的这最后两门技法，非侵略之器，而是守护之具——它证明了仅凭双拳，辅以坚定心志与精纯内气，便能抗衡世间任何兵刃与法术。",
                            "（ . . . ）",
                            "谨以此最后一册笔记，记录这段修行之路。元道·武不止是武学，更是一种处世之道。愿得见此书者，能领悟刚柔并济的真谛，以谦逊之心持强者之力，勇敢走下去。"
                        )}
                    },
                    midText: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "\"The Pinnacle of Qi and Martial Arts\"##~gr~Allows you to learn the following Yuan Dao·Wu abilities:~/~##~lg~Cloud Dispelling Palm~/~#~lg~Inner Energy Surges~/~##Reading this book grants some ~y~Experience~/~." },
                        { ModLanguage.Chinese, "《气武合一巅峰篇》##~gr~可以学习若干元道·武能力：~/~##~lg~排云掌~/~#~lg~气贯周身~/~##阅读本书可以获得一定的~y~经验~/~。" }
                    },
                    description: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "The final volume of Yuan Dao·Wu records, detailing the pinnacle skills of this Eastern martial art—unarmed combat techniques that merge inner Qi with Aldor's Aether, achieving unparalleled offensive and defensive power." },
                        { ModLanguage.Chinese, "元道·武的收官之作，记录了这门东方武术的巅峰技艺。将内气与奥尔多大陆的以太能量深度融合，无需兵刃即可发挥出无匹的攻防之力，是徒手格斗的终极境界。" }
                    },
                    type: new Dictionary<ModLanguage, string>
                    {
                        { ModLanguage.English, "Recorded by a Wanderer of Eastern Martial Arts" },
                        { ModLanguage.Chinese, "录于东方武道游历者" }
                    }
                )
            );


            Msl.LoadGML("gml_Object_o_npc_scribe_mannshire_Create_0")
                .MatchFrom("ds_list_add(singular_stock_list")
                .InsertBelow("ds_list_add(singular_stock_list, o_inv_book_yuandaowu1)")
                .Save();

            Msl.LoadGML("gml_Object_o_npc_merchant_jibei_brynn_Other_19")
                .MatchAll()
                .InsertBelow("ds_list_add(singular_stock_list, o_inv_book_yuandaowu2)")
                .Save();
        }
    }
}