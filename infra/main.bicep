param location string = resourceGroup().location
param uniqueSeed string = '${resourceGroup().id}-${deployment().name}'

var webAppName = 'web-client'
var webAppImageName = 'todo'

var imagesApiName = 'images-api'
var imagesApiImageName = 'images-api'

var phrasesApiName = 'phrases-api'
var phrasesApiImageName = 'phrases-api'


resource containerRegistry 'Microsoft.ContainerRegistry/registries@2022-12-01' ={
  name: '${deployment().name}-innvolve-presentation'
  location: location
  sku: {
    name: 'Basic'
  }
  properties: {
    adminUserEnabled: true
    
  }
}


module containerAppsEnvironment 'modules/infra/container-apps-env.bicep' = {
  name: '${deployment().name}-infra-container-app-env'
  params: {
    location: location
    uniqueSeed: uniqueSeed
  }
}

module phrasesApi 'modules/apps/api.bicep' = {
  name: '${deployment().name}-app-${phrasesApiName}'

  dependsOn:[
    containerAppsEnvironment
  ]
  params: {
    location: location
    apiName: phrasesApiName
    imageName: phrasesApiImageName
    containerAppsEnvironmentId: containerAppsEnvironment.outputs.id
    containerAppsEnvironmentDomain: containerAppsEnvironment.outputs.domain
  }
}

module imagesApi 'modules/apps/api.bicep' = {
  name: '${deployment().name}-app-${imagesApiName}'

  dependsOn:[
    containerAppsEnvironment
  ]
  params: {
    location: location
    apiName: imagesApiName
    imageName: imagesApiImageName
    containerAppsEnvironmentId: containerAppsEnvironment.outputs.id
    containerAppsEnvironmentDomain: containerAppsEnvironment.outputs.domain
  }
}

module blazorClient 'modules/apps/app.bicep' = {
  name: '${deployment().name}-app-blazor-client'

  dependsOn:[
    phrasesApi
    imagesApi
  ]

  params: {
    location: location
    webAppName:webAppName
    imageName:webAppImageName
    imagesApiName: imagesApiName
    phrasesApiName: phrasesApiName
    containerAppsEnvironmentId: containerAppsEnvironment.outputs.id
    containerAppsEnvironmentDomain: containerAppsEnvironment.outputs.domain
  }
}
