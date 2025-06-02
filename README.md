# ASP.NET MVC Web Example

## 注意事項
* `sln`檔案為Sonarqube掃描必須檔案，若僅部署服務不一定需要此sln檔案，僅原始碼+Dockerfile即可
* `ASP.NET 8.0 Container中，Web核心埠從 80 變更為 8080，使用此版本務必留意各設定需進行調整
* 專案內的`.csproj`檔內有此專案的版本定義
 
## 流程說明
![](https://i.imgur.com/toASHDl.png)

## 建立專案
* 放程式碼進去

請將全部的程式碼包含.sln檔 放進 `app`資料夾內

![](https://i.imgur.com/gJtcs4m.png)

## 開啟專案內的`.csproj`，確認版本(已知版本者可略過此步驟)
- 示範的版本是NETCoreApp 8.0，請確認版本後，進行下一步驟
```
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <RootNamespace>ASP_MVC_example</RootNamespace>
  </PropertyGroup>

</Project>
```

## 修改.gitlab-ci.yml檔案
- 範本預設的是NETCoreApp 8.0，如果開發者使用的版本不同，請依以下指示進行修改:

### 版本設定說明
本範本預設為NETCoreApp 8.0，如使用不同版本請修改`CHART_ASP_TAG`和相關設定。

**ASP.NET 8.0 (預設)範本：**
```
Test--SonarQube source code scan:
  variables:
    iiidevops: sonarqube
    CHART_TYPE: asp_dot_net
    CHART_ASP_TAG: "8.0"
  only:
    - master
```

**若使用ASP.NET 6.0或更早版本，需額外修改：**
1. 將 `CHART_ASP_TAG` 改為 `"6.0"` (或對應版本)
2. 將 `CHART_WEB_PORT` 從 `8080` 改為 `80`
## 修改.gitlab-ci.yml檔案中之設定
- 依實際Dockerfile檔案路徑，更新設定內容
- 修改位置及修改後示意如下圖

![](https://i.imgur.com/U1FpHV3.png)

## 修改iiidevops/sonarqube/SonarScan
- 依實際sln名稱及路徑，更新設定內容
- 修改後示意如下圖︰

![](https://i.imgur.com/DjEQaIc.png)


## ASP.NET 8.0 預設調整說明
- 本範本預設使用ASP.NET 8.0，已將gitlab-ci.yml中CHART_WEB_PORT調整為8080 (因ASP.NET 8.0 Container埠變更)
- 若使用其他版本(如6.0或更早版本)，需進行以下調整：
  1. 將`CHART_ASP_TAG`改為對應版本 (如`"6.0"`)
  2. 將`CHART_WEB_PORT`從`8080`改回`80`


## 專案資料夾與檔案格式說明
檔案可按照需求做修改，此主要針對大部分專案規定來進行描述，針對不同專案可能會有些許變化，詳細使用方式請參考iiidevops教學說明文件。

| 型態 | 名稱 | 說明 | 路徑 |
| --- | --- | --- | --- |
| 資料夾 | app | 專案主要程式碼 | 根目錄 |
| 資料夾 | iiidevops | :warning: (不可更動)devops系統測試所需檔案 | 在根目錄 |
| 檔案 | .gitlab-ci.yml | :warning: (不可更動)devops系統測試所需檔案 | 在根目錄 |
| 檔案 | pipeline_settings.json | :warning: (不可更動)devops系統測試所需檔案 | 在iiidevops資料夾內 |
| 檔案 | app.env | (可調整)實證環境 `web`環境變數添加 | 在iiidevops資料夾內 | 
| 檔案 | SonarScan | (可調整)devops sonarqube 掃描執行檔案 | iiidevops/sonarqube資料夾內 |
| 檔案 | postman_collection.json | (可調整)devops newman部署測試案例檔案 | iiidevops/postman資料夾內 |
| 檔案 | postman_environment.json | (可調整)devops newman部署測試環境變數檔案 | iiidevops/postman資料夾內 |
| 檔案 | Dockerfile | (可調整)devops k8s環境部署檔案 |  |

## iiidevops
* 專案內`.gitlab-ci.yml`如需要更動，請務必注意，避免影響現有的功能。
* `iiidevops`資料夾內`pipeline_settings.json`請勿更動。
* `postman`資料夾內則是您在devops管理網頁上的Postman-collection(newman)自動測試檔案，devops系統會以`postman`資料夾內檔案做自動測試。
* 若使用上有任何問題請至`https://www.iiidevops.org/`內的`聯絡方式`頁面做問題回報。

## Reference and FAQ

* [sonarscanner-for-msbuild/](https://docs.sonarqube.org/latest/analysis/scan/sonarscanner-for-msbuild/)
* [activity-diagram-beta](https://plantuml.com/zh/activity-diagram-beta)
<a name="my-anchor"></a>

* [End of Support Notification](https://docs.sonarsource.com/sonarqube/9.9/analyzing-source-code/scanners/sonarscanner-for-dotnet/)
* [EOL for dotnet](https://dotnet.microsoft.com/en-us/download/dotnet)
* [aspnet-port changed](https://learn.microsoft.com/zh-tw/dotnet/core/compatibility/containers/8.0/aspnet-port)

:::info
**Find this document incomplete?** Leave a comment!
:::

###### tags: `iiidevops Templates README` `Sonarqube免費版` `Documentation`

...
