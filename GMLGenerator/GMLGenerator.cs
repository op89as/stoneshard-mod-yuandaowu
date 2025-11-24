using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FristMod.GMLGenerator
{
    public class SkillData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string ObjectName { get; set; } = string.Empty;
        public string VariableName { get; set; } = string.Empty;

        public SkillData() { }

        public SkillData(int x, int y, string objectName, string variableName)
        {
            X = x;
            Y = y;
            ObjectName = objectName;
            VariableName = variableName;
        }
    }
    public class LineData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string SpriteName { get; set; } = string.Empty;
        public string VariableName { get; set; } = string.Empty;

        public LineData() { }

        public LineData(int x, int y, string spriteName, string variableName)
        {
            X = x;
            Y = y;
            SpriteName = spriteName;
            VariableName = variableName;
        }
    }
    public class ConnectionConfig
    {
        public string SourceVariable { get; set; } = string.Empty;
        public string[] TargetVariables { get; set; } = Array.Empty<string>();
        public string ConnectionType { get; set; } = string.Empty;// "points", "lines", "line_to_points"

        public ConnectionConfig() { }

        public ConnectionConfig(string source, string[] targets, string type = "points")
        {
            SourceVariable = source;
            TargetVariables = targets;
            ConnectionType = type;
        }
    }
    public class GMLSkillCodeGenerator
    {
        // 预定义的技能对象常量
        public static class SkillObjects
        {
            public const string ALCHEMY = "o_skill_witcher_alchemy_ico";
            public const string QUEN = "o_skill_quen_sign_ico";
            public const string AXII = "o_skill_axii_sign_ico";
            public const string YRDEN = "o_skill_yrden_sign_ico";
            public const string GRASSES = "o_skill_trial_of_grasses";
            public const string AARD = "o_skill_aard_sign_ico";
            public const string IGNI = "o_skill_igni_sign_ico";
        }

        // 基础函数（内部使用）
        private static string AddSkill(int x, int y, string skillObject, string variableName)
        {
            return $@"pushi.e {x}
conv.i.v
pushi.e {y}
conv.i.v
pushi.e {skillObject}
conv.i.v
push.v self.connectionsRender
push.i gml_Script_ctr_SkillPoint
conv.i.v
call.i @@NewGMLObject@@(argc=5)
pop.v.v local.{variableName}";
        }

        // 主函数 - 接受技能对象数组
        public static string AddSkills(SkillData[] skills)
        {
            if (skills == null || skills.Length == 0)
                return string.Empty;

            var codeLines = new List<string>();

            foreach (var skill in skills)
            {
                if (skill == null) continue;

                string skillCode = AddSkill(skill.X, skill.Y, skill.ObjectName, skill.VariableName);
                codeLines.Add(skillCode);
            }

            return string.Join("\n", codeLines);
        }

        // 便捷方法 - 使用预定义技能类型
        public static string AddSkillsByType(List<(int x, int y, string type, string varName)> skillDefinitions)
        {
            var skills = new List<SkillData>();

            foreach (var def in skillDefinitions)
            {
                string objectName = def.type switch
                {
                    "alchemy" => SkillObjects.ALCHEMY,
                    "quen" => SkillObjects.QUEN,
                    "axii" => SkillObjects.AXII,
                    "yrden" => SkillObjects.YRDEN,
                    "grasses" => SkillObjects.GRASSES,
                    "aard" => SkillObjects.AARD,
                    "igni" => SkillObjects.IGNI,
                    _ => throw new ArgumentException($"未知的技能类型: {def.type}")
                };

                skills.Add(new SkillData(def.x, def.y, objectName, def.varName));
            }

            return AddSkills(skills.ToArray());
        }
    }
    public class GMLLineCodeGenerator
    {

        // 创建连线对象的基础函数
        public static string CreateLine(int x, int y, string lineSprite, string variableName)
        {
            return $@"pushi.e {y}
conv.i.v
pushi.e {x}
conv.i.v
pushi.e {lineSprite}
conv.i.v
push.v self.connectionsRender
push.i gml_Script_ctr_SkillLine
conv.i.v
call.i @@NewGMLObject@@(argc=5)
pop.v.v local.{variableName}";
        }

        // 批量创建连线对象
        public static string CreateLines(LineData[] lines)
        {
            if (lines == null || lines.Length == 0)
                return string.Empty;

            var codeLines = new List<string>();

            foreach (var line in lines)
            {
                if (line == null) continue;

                string lineCode = CreateLine(line.X, line.Y, line.SpriteName, line.VariableName);
                codeLines.Add(lineCode);
            }

            return string.Join("\n", codeLines);
        }

        // 单点连接（技能点连接到技能点）
        public static string ConnectPoints(string sourceVar, params string[] targetVars)
        {
            var codeLines = new List<string>();

            foreach (var targetVar in targetVars)
            {
                codeLines.Add($@"pushloc.v local.{sourceVar}
pushloc.v local.{targetVar}
call.i @@NewGMLArray@@(argc=1)
dup.v 1 8
dup.v 0
push.v stacktop.addConnectedPoints
callv.v 1
popz.v");
            }

            return string.Join("\n", codeLines);
        }

        // 单线连接（技能点连接到线条）
        public static string ConnectPointToLines(string pointVar, params string[] lineVars)
        {
            var codeLines = new List<string>();

            foreach (var lineVar in lineVars)
            {
                codeLines.Add($@"pushloc.v local.{pointVar}
pushloc.v local.{lineVar}
call.i @@NewGMLArray@@(argc=1)
dup.v 1 8
dup.v 0
push.v stacktop.addConnectedLines
callv.v 1
popz.v");
            }

            return string.Join("\n", codeLines);
        }

        // 多线连接（批量连接点到多条线）
        public static string ConnectPointToMultipleLines(string pointVar, string[] lineVars)
        {
            if (lineVars == null || lineVars.Length == 0)
                return string.Empty;

            var codeLines = new List<string>();

            // 构建参数栈
            codeLines.Add($@"pushloc.v local.{pointVar}");

            foreach (var lineVar in lineVars)
            {
                codeLines.Add($@"pushloc.v local.{lineVar}");
            }

            codeLines.Add($@"call.i @@NewGMLArray@@(argc={lineVars.Length})");
            codeLines.Add($@"dup.v {lineVars.Length} 8");
            codeLines.Add($@"dup.v 0");
            codeLines.Add($@"push.v stacktop.addConnectedLines");
            codeLines.Add($@"callv.v {lineVars.Length}");
            codeLines.Add($@"popz.v");

            return string.Join("\n", codeLines);
        }

        // 线条连接到点
        public static string ConnectLineToPoints(string lineVar, params string[] pointVars)
        {
            var codeLines = new List<string>();

            foreach (var pointVar in pointVars)
            {
                codeLines.Add($@"pushloc.v local.{lineVar}
pushloc.v local.{pointVar}
call.i @@NewGMLArray@@(argc=1)
dup.v 1 8
dup.v 0
push.v stacktop.addConnectedPoints
callv.v 1
popz.v");
            }

            return string.Join("\n", codeLines);
        }

        // 根据连接配置生成连接代码
        public static string GenerateConnections(ConnectionConfig[] connections)
        {
            if (connections == null || connections.Length == 0)
                return string.Empty;

            var codeLines = new List<string>();

            foreach (var config in connections)
            {
                if (config == null || config.TargetVariables == null) continue;

                switch (config.ConnectionType.ToLower())
                {
                    case "points":
                        codeLines.Add(ConnectPoints(config.SourceVariable, config.TargetVariables));
                        break;
                    case "lines":
                        if (config.TargetVariables.Length == 1)
                            codeLines.Add(ConnectPointToLines(config.SourceVariable, config.TargetVariables));
                        else
                            codeLines.Add(ConnectPointToMultipleLines(config.SourceVariable, config.TargetVariables));
                        break;
                    case "line_to_points":
                        codeLines.Add(ConnectLineToPoints(config.SourceVariable, config.TargetVariables));
                        break;
                }
            }

            return string.Join("\n", codeLines);
        }
    }
    public class GMLCodeCombiner
    {
        public static string CombineSkillAndLineCode(string skillCode, string lineCode, string connectionCode = "")
        {
            var combined = new List<string>
            {
                // 添加头部代码
                ":[0]",
                "call.i event_inherited(argc=0)",
                "popz.v"
            };

            // 添加技能代码
            if (!string.IsNullOrEmpty(skillCode))
            {
                combined.Add(skillCode);
            }

            // 添加分隔符和连线代码
            if (!string.IsNullOrEmpty(lineCode))
            {
                combined.Add(";;; Connect each skills using lines");
                combined.Add(lineCode);
            }

            // 添加连接代码
            if (!string.IsNullOrEmpty(connectionCode))
            {
                if (string.IsNullOrEmpty(lineCode))
                {
                    combined.Add(";;; Connect each skills using lines");
                }
                combined.Add(connectionCode);
            }

            // 添加尾部代码
            combined.Add(":[end]");

            return string.Join("\n", combined);
        }

        // 完整生成技能树
        public static string GenerateCompleteSkillTree(
            SkillData[] skills,
            LineData[] lines,
            ConnectionConfig[] connections)
        {
            ArgumentNullException.ThrowIfNull(connections);
            string skillCode = GMLSkillCodeGenerator.AddSkills(skills);
            string lineCode = GMLLineCodeGenerator.CreateLines(lines);
            string connectionCode = connections != null ? GMLLineCodeGenerator.GenerateConnections(connections) : "";

            return CombineSkillAndLineCode(skillCode, lineCode, connectionCode);
        }
    }
}
