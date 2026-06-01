using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseOrm
{
    /// <summary>
    /// 条码列配置管理器 - 负责JSON配置的读写
    /// </summary>
    public class BarcodeConfigManager
    {
        // 配置目录：直接放在软件运行目录下的"配置文件"文件夹
        private static readonly string CONFIG_DIR = Path.Combine(Application.StartupPath, "配置文件");
        private static readonly string CONFIG_FILE = Path.Combine(CONFIG_DIR, "barcodeColumnConfig.json");
        private static readonly string MULTI_CONFIG_FILE = Path.Combine(CONFIG_DIR, "multiProductConfig.json");

        // === 多产品配置 ===

        /// <summary>
        /// 加载多产品配置
        /// </summary>
        public static MultiProductConfig LoadMultiConfig()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[Config] 查找配置文件: " + MULTI_CONFIG_FILE);
                System.Diagnostics.Debug.WriteLine("[Config] 文件存在: " + File.Exists(MULTI_CONFIG_FILE));
                if (File.Exists(MULTI_CONFIG_FILE))
                {
                    string json = File.ReadAllText(MULTI_CONFIG_FILE, Encoding.UTF8);
                    var config = JsonConvert.DeserializeObject<MultiProductConfig>(json);
                    if (config != null && config.Products != null && config.Products.Count > 0)
                    {
                        System.Diagnostics.Debug.WriteLine("[Config] 成功加载 " + config.Products.Count + " 个产品:");
                        foreach (var p in config.Products)
                            System.Diagnostics.Debug.WriteLine(string.Format("[Config]   {0}: 主码={1}, Enable={2}, CodeStatus={3}",
                                p.ProductName,
                                p.BarcodeConfig?.Groups?.FirstOrDefault()?.Columns?.FirstOrDefault()?.Address ?? "无",
                                p.EnableReadAddress, p.CodeStatusAddress));
                        return config;
                    }
                    System.Diagnostics.Debug.WriteLine("[Config] JSON解析结果为空，使用默认配置");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("[Config] 文件不存在，使用默认配置");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[Config] 加载失败: " + ex.Message);
            }
            return CreateDefaultMultiConfig();
        }

        /// <summary>
        /// 保存多产品配置
        /// </summary>
        public static void SaveMultiConfig(MultiProductConfig config)
        {
            try
            {
                if (!Directory.Exists(CONFIG_DIR))
                    Directory.CreateDirectory(CONFIG_DIR);
                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(MULTI_CONFIG_FILE, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("保存多产品配置失败: " + ex.Message);
            }
        }

        /// <summary>
        /// 创建默认3产品配置
        /// </summary>
        public static MultiProductConfig CreateDefaultMultiConfig()
        {
            var config = new MultiProductConfig();
            string[] names = { "压装", "推卡夹", "返工" };
            string[] okTables = { "OKTable_压装", "OKTable_推卡夹", "OKTable_返工" };
            string[] ngTables = { "NGTable_压装", "NGTable_推卡夹", "NGTable_返工" };
            int[] enableAddrs = { 80, 82, 84 };
            int[] statusAddrs = { 676, 678, 680 };
            for (int i = 0; i < 3; i++)
            {
                config.Products.Add(new ProductConfig
                {
                    ProductName = names[i],
                    EnableReadAddress = "DB18." + enableAddrs[i],
                    CodeStatusAddress = "DB18." + statusAddrs[i],
                    OkTableName = okTables[i],
                    NgTableName = ngTables[i],
                    BarcodeConfig = CreateDefaultConfig()
                });
            }
            return config;
        }

        /// <summary>
        /// 获取配置目录路径（用于日志显示）
        /// </summary>
        public static string GetConfigDir()
        {
            return MULTI_CONFIG_FILE;
        }

        // === 单产品旧配置（兼容） ===

        /// <summary>
        /// 加载配置，如果文件不存在则返回默认配置
        /// </summary>
        public static BarcodeConfig LoadConfig()
        {
            try
            {
                if (File.Exists(CONFIG_FILE))
                {
                    string json = File.ReadAllText(CONFIG_FILE, Encoding.UTF8);
                    return JsonConvert.DeserializeObject<BarcodeConfig>(json) ?? CreateDefaultConfig();
                }
            }
            catch (Exception ex)
            {
                // 加载失败时使用默认配置
                System.Diagnostics.Debug.WriteLine("加载条码配置失败: " + ex.Message);
            }

            return CreateDefaultConfig();
        }

        /// <summary>
        /// 保存配置到JSON文件
        /// </summary>
        public static void SaveConfig(BarcodeConfig config)
        {
            try
            {
                if (!Directory.Exists(CONFIG_DIR))
                    Directory.CreateDirectory(CONFIG_DIR);

                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(CONFIG_FILE, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("保存条码配置失败: " + ex.Message);
            }
        }

        /// <summary>
        /// 创建默认配置（兼容旧的5个地址格式）
        /// </summary>
        public static BarcodeConfig CreateDefaultConfig()
        {
            var config = new BarcodeConfig();

            // === 主码（String[50] at DB18.8） + 状态标志 ===
            config.Groups.Add(new CodeGroupConfig
            {
                GroupName = "主码",
                Columns = new List<BarcodeColumnConfig>
                {
                    new BarcodeColumnConfig { DisplayName = "主码内容", Address = "DB18.8", DataType = "STRING", DbColumnName = "主码" },
                    new BarcodeColumnConfig { DisplayName = "当前是否有码", Address = "DB18.268", DataType = "INT16", DbColumnName = "当前是否有码" },
                    new BarcodeColumnConfig { DisplayName = "是否有卡夹", Address = "DB18.270", DataType = "INT16", DbColumnName = "是否有卡夹" },
                    new BarcodeColumnConfig { DisplayName = "是否是返工件", Address = "DB18.272", DataType = "INT16", DbColumnName = "是否是返工件" },
                    new BarcodeColumnConfig { DisplayName = "压装总成状态", Address = "DB18.338", DataType = "INT16", DbColumnName = "压装总成状态" },
                    new BarcodeColumnConfig { DisplayName = "推卡夹状态", Address = "DB18.348", DataType = "INT16", DbColumnName = "推卡夹状态" },
                    new BarcodeColumnConfig { DisplayName = "压装失败位置", Address = "DB18.350", DataType = "INT16", DbColumnName = "压装失败位置" },
                }
            });

            // === 副码1（String[50] at DB18.60） ===
            config.Groups.Add(new CodeGroupConfig
            {
                GroupName = "副码1",
                Columns = new List<BarcodeColumnConfig>
                {
                    new BarcodeColumnConfig { DisplayName = "副码1内容", Address = "DB18.60", DataType = "STRING", DbColumnName = "副码1" },
                    new BarcodeColumnConfig { DisplayName = "装加热塞位移", Address = "DB18.274", DataType = "REAL", DbColumnName = "副码1装加热塞位移" },
                    new BarcodeColumnConfig { DisplayName = "装加热塞力", Address = "DB18.278", DataType = "REAL", DbColumnName = "副码1装加热塞力" },
                    new BarcodeColumnConfig { DisplayName = "最大力位移", Address = "DB18.282", DataType = "REAL", DbColumnName = "副码1最大力位移" },
                    new BarcodeColumnConfig { DisplayName = "最大力", Address = "DB18.286", DataType = "REAL", DbColumnName = "副码1最大力" },
                    new BarcodeColumnConfig { DisplayName = "结果", Address = "DB18.340", DataType = "INT16", DbColumnName = "副码1结果" },
                }
            });

            // === 副码2（String[50] at DB18.112） ===
            config.Groups.Add(new CodeGroupConfig
            {
                GroupName = "副码2",
                Columns = new List<BarcodeColumnConfig>
                {
                    new BarcodeColumnConfig { DisplayName = "副码2内容", Address = "DB18.112", DataType = "STRING", DbColumnName = "副码2" },
                    new BarcodeColumnConfig { DisplayName = "装加热塞位移", Address = "DB18.290", DataType = "REAL", DbColumnName = "副码2装加热塞位移" },
                    new BarcodeColumnConfig { DisplayName = "装加热塞力", Address = "DB18.294", DataType = "REAL", DbColumnName = "副码2装加热塞力" },
                    new BarcodeColumnConfig { DisplayName = "最大力位移", Address = "DB18.298", DataType = "REAL", DbColumnName = "副码2最大力位移" },
                    new BarcodeColumnConfig { DisplayName = "最大力", Address = "DB18.302", DataType = "REAL", DbColumnName = "副码2最大力" },
                    new BarcodeColumnConfig { DisplayName = "结果", Address = "DB18.342", DataType = "INT16", DbColumnName = "副码2结果" },
                }
            });

            // === 副码3（String[50] at DB18.164） ===
            config.Groups.Add(new CodeGroupConfig
            {
                GroupName = "副码3",
                Columns = new List<BarcodeColumnConfig>
                {
                    new BarcodeColumnConfig { DisplayName = "副码3内容", Address = "DB18.164", DataType = "STRING", DbColumnName = "副码3" },
                    new BarcodeColumnConfig { DisplayName = "装加热塞位移", Address = "DB18.306", DataType = "REAL", DbColumnName = "副码3装加热塞位移" },
                    new BarcodeColumnConfig { DisplayName = "装加热塞力", Address = "DB18.310", DataType = "REAL", DbColumnName = "副码3装加热塞力" },
                    new BarcodeColumnConfig { DisplayName = "最大力位移", Address = "DB18.314", DataType = "REAL", DbColumnName = "副码3最大力位移" },
                    new BarcodeColumnConfig { DisplayName = "最大力", Address = "DB18.318", DataType = "REAL", DbColumnName = "副码3最大力" },
                    new BarcodeColumnConfig { DisplayName = "结果", Address = "DB18.344", DataType = "INT16", DbColumnName = "副码3结果" },
                }
            });

            // === 副码4（String[50] at DB18.216） ===
            config.Groups.Add(new CodeGroupConfig
            {
                GroupName = "副码4",
                Columns = new List<BarcodeColumnConfig>
                {
                    new BarcodeColumnConfig { DisplayName = "副码4内容", Address = "DB18.216", DataType = "STRING", DbColumnName = "副码4" },
                    new BarcodeColumnConfig { DisplayName = "装加热塞位移", Address = "DB18.322", DataType = "REAL", DbColumnName = "副码4装加热塞位移" },
                    new BarcodeColumnConfig { DisplayName = "装加热塞力", Address = "DB18.326", DataType = "REAL", DbColumnName = "副码4装加热塞力" },
                    new BarcodeColumnConfig { DisplayName = "最大力位移", Address = "DB18.330", DataType = "REAL", DbColumnName = "副码4最大力位移" },
                    new BarcodeColumnConfig { DisplayName = "最大力", Address = "DB18.334", DataType = "REAL", DbColumnName = "副码4最大力" },
                    new BarcodeColumnConfig { DisplayName = "结果", Address = "DB18.346", DataType = "INT16", DbColumnName = "副码4结果" },
                }
            });

            return config;
        }

        /// <summary>
        /// 获取所有可用的数据类型列表
        /// </summary>
        public static string[] GetDataTypes()
        {
            return new[] { "STRING", "INT16", "REAL", "BYTE" };
        }

        /// <summary>
        /// 获取所有组名列表
        /// </summary>
        public static string[] GetGroupNames()
        {
            return new[] { "主码", "副码1", "副码2", "副码3", "副码4", "额外数据" };
        }
    }
}
