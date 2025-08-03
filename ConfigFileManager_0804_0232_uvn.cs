// 代码生成时间: 2025-08-04 02:32:02
using System;
using System.IO;
using System.Text;
using System.Configuration;
using System.Windows; // For WPF

namespace ConfigFileApp
{
    public class ConfigFileManager
    {
        // 文件路径
        private readonly string _configFilePath;

        // 构造函数
        public ConfigFileManager(string configFilePath)
        {
            _configFilePath = configFilePath;
        }

        // 加载配置文件
        public AppConfig LoadConfig()
        {
            if (!File.Exists(_configFilePath))
            {
                throw new FileNotFoundException("配置文件未找到。", _configFilePath);
            }

            var configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = _configFilePath };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            return new AppConfig
            {
                // 假设我们有一个AppConfig类，里面有我们需要的配置信息
                Setting1 = configuration.AppSettings.Settings["Setting1"].Value,
                Setting2 = configuration.AppSettings.Settings["Setting2"].Value
            };
        }

        // 保存配置文件
        public void SaveConfig(AppConfig config)
        {
            if (!File.Exists(_configFilePath))
            {
                throw new FileNotFoundException("配置文件未找到。", _configFilePath);
            }

            using (var stream = new FileStream(_configFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                var configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = _configFilePath };
                var configuration = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

                // 更新配置项
                configuration.AppSettings.Settings["Setting1"].Value = config.Setting1;
                configuration.AppSettings.Settings["Setting2"].Value = config.Setting2;

                // 保存更改
                configuration.Save(ConfigurationSaveMode.Modified);
            }
        }
    }

    // 配置类，用于存储配置信息
    public class AppConfig
    {
        public string Setting1 { get; set; }
        public string Setting2 { get; set; }
    }
}
