# ASP.NET MVC Web Example

## 注意事項
* `sln`一定得放著根目錄
* 根目錄`sln`檔案為Sonarqube掃描必須檔案，若僅部屬服務不一定需要此sln檔案，僅原始碼+Dockerfile即可
* 掃描後仍需檢查確認送至Sonarqube UI的檔案是否相符

## 流程說明
![](https://i.imgur.com/l3UlTxh.png)

## 建立專案
* 放程式碼進去
請將程式碼放進 `app`資料夾內，並將將sln提至根目錄

![](https://i.imgur.com/7cjHk66.png)

## .netCore 6.0 
- 修改.rancher-pipeline.yaml檔案
- 範本預設的是NETCoreApp 3.1，如果開發者使用的版本比較新，如6.0，請依以下指示進行修改:
### 請依原本範本進行修改
![](https://i.imgur.com/D3aHBOY.png)
### 修改範本(修改後)
如果開發環境比NETCoreApp 3.1版本更新，要增加一行tag` asp_dot_net.tag: ;`這邊請根據DockerFile裡面的版本進行修正。
- 示意如下：
![](https://i.imgur.com/gPErpQk.png)
- 文字範本如下： 
```
- name: Test--SonarQube for ASP.NET
  iiidevops: sonarqube
  steps:
  - applyAppConfig:
      answers:
        git.branch: ${CICD_GIT_BRANCH}
        git.commitID: ${CICD_GIT_COMMIT}
        git.repoName: ${CICD_GIT_REPO_NAME}
        git.url: ${CICD_GIT_URL}
        harbor.host: harbor-itsdevops.iii.org.tw
        pipeline.sequence: ${CICD_EXECUTION_SEQUENCE}
        type: asp_dot_net
        asp_dot_net.image: mcr.microsoft.com/dotnet/sdk
        asp_dot_net.tag: 6.0
      catalogTemplate: cattle-global-data:iii-dev-charts3-scan-sonarqube
      name: ${CICD_GIT_REPO_NAME}-${CICD_GIT_BRANCH}-sq
      targetNamespace: ${CICD_GIT_REPO_NAME}
      version: 0.3.1
  when:
    branch:
      include:
      - master
      - develop
```

## 修改sln檔案
這個是因為前面有一個部分修改了專案的路徑從`專案名稱`資料夾，變成`app`資料夾，因此會有解析錯誤的問題需要修正。在下面說明將以範本內附送的sln檔案為例，變化主要就是`Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ASP-MVC-example", "ASP-MVC-example\ASP-MVC-example.csproj", "{7898E239-AEB3-49F7-9707-394E19EADFE6}"`這裡變成`Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ASP-MVC-example", "app\ASP-MVC-example.csproj", "{7898E239-AEB3-49F7-9707-394E19EADFE6}"
EndProject`。也就是`ASP-MVC-example\ASP-MVC-example.csproj`變成`app\ASP-MVC-example.csproj`
### 修改前
```
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.31129.286
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ASP-MVC-example", "ASP-MVC-example\ASP-MVC-example.csproj", "{7898E239-AEB3-49F7-9707-394E19EADFE6}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{7898E239-AEB3-49F7-9707-394E19EADFE6}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{7898E239-AEB3-49F7-9707-394E19EADFE6}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{7898E239-AEB3-49F7-9707-394E19EADFE6}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{7898E239-AEB3-49F7-9707-394E19EADFE6}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {B05AE01E-CEBE-4344-B3DA-646698293E91}
	EndGlobalSection
EndGlobal
```

### 修改後
```
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.31129.286
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ASP-MVC-example", "app\ASP-MVC-example.csproj", "{7898E239-AEB3-49F7-9707-394E19EADFE6}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{7898E239-AEB3-49F7-9707-394E19EADFE6}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{7898E239-AEB3-49F7-9707-394E19EADFE6}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{7898E239-AEB3-49F7-9707-394E19EADFE6}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{7898E239-AEB3-49F7-9707-394E19EADFE6}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {B05AE01E-CEBE-4344-B3DA-646698293E91}
	EndGlobalSection
EndGlobal
```

## 如果沒有Build Sonarqube會跳出甚麼錯誤
![](https://i.imgur.com/X5HUTPr.png)
```
09:29:30.676  The SonarScanner for MSBuild integration failed: SonarQube was unable to collect the required information about your projects.
Possible causes:
  1. The project has not been built - the project must be built in between the begin and end steps
  2. An unsupported version of MSBuild has been used to build the project. Currently MSBuild 14.0.25420.1 and higher are supported.
  3. The begin, build and end steps have not all been launched from the same folder
  4. None of the analyzed projects have a valid ProjectGuid and you have not used a solution (.sln)
09:29:30.676  Generation of the sonar-properties file failed. Unable to complete the analysis.
09:29:30.682  Post-processing failed. Exit code: 1
```


## 專案資料夾與檔案格式說明
檔案可按照需求做修改，此主要針對大部分專案規定來進行描述，針對不同專案可能會有些許變化，詳細使用方式請參考iiidevops教學說明文件。

| 型態 | 名稱 | 說明 | 路徑 |
| --- | --- | --- | --- |
| 資料夾 | app | 專案主要程式碼 | 根目錄 |
| 資料夾 | iiidevops | :warning: (不可更動)devops系統測試所需檔案 | 在根目錄 |
| 檔案 | .rancher-pipeline.yml | :warning: (不可更動)devops系統測試所需檔案 | 在根目錄 |
| 檔案 | pipeline_settings.json | :warning: (不可更動)devops系統測試所需檔案 | 在iiidevops資料夾內 |
| 檔案 | app.env | (可調整)實證環境 `web`環境變數添加 | 在iiidevops資料夾內 | 
| 檔案 | postman_collection.json | (可調整)devops newman部屬測試案例檔案 | iiidevops/postman資料夾內 |
| 檔案 | postman_environment.json | (可調整)devops newman部屬測試環境變數檔案 | iiidevops/postman資料夾內 |
| 檔案 | sideex.json | (可調整)devops Sideex部屬測試檔案 | iiidevops/sideex資料夾內 |
| 檔案 | Dockerfile | (可調整)devops k8s環境部屬檔案 | 根目錄 |

## iiidevops
* 專案內`.rancher-pipeline.yml`請勿更動，產品系統設計上不支援pipeline修改，但若預設`README.md`文件內有寫引導說明部分則例外。
* `iiidevops`資料夾內`pipeline_settings.json`請勿更動。
* `postman`資料夾內則是您在devops管理網頁上的Postman-collection(newman)自動測試檔案，devops系統會以`postman`資料夾內檔案做自動測試。
* `Dockerfile`內可能會看到很多來源都加上前墜`dockerhub`，此為必須需求，為使image能從iiidevops產品所架設的`harbor`上作為來源擷取出Docker Hub的image來源。
* 若使用上有任何問題請至`https://www.iiidevops.org/`內的`聯絡方式`頁面做問題回報。

## Reference and FAQ

* [sonarscanner-for-msbuild/](https://docs.sonarqube.org/latest/analysis/scan/sonarscanner-for-msbuild/)
* [activity-diagram-beta](https://plantuml.com/zh/activity-diagram-beta)
:::info
**Find this document incomplete?** Leave a comment!
:::

###### tags: `iiidevops Templates README` `Sonarqube免費版` `Documentation`
