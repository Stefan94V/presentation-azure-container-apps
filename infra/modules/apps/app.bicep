param location string

param webAppName string
param imageName string
param phrasesApiName string
param imagesApiName string
param containerAppsEnvironmentId string
param containerAppsEnvironmentDomain string

resource containerApp 'Microsoft.App/containerApps@2022-03-01' = {
  name: webAppName
  location: location
  properties: {
    managedEnvironmentId: containerAppsEnvironmentId
    template: {
      containers: [
        {
          name: webAppName
          image: '${imageName}:latest'
          env: [
            {
              name: 'ASPNETCORE_ENVIRONMENT'
              value: 'Development'
            }
            {
              name: 'ASPNETCORE_URLS'
              value: 'http://0.0.0.0:80'
            }
            {
              name: 'Apis_ImagesApi_BaseUrl'
              value: 'https://${imagesApiName}.${containerAppsEnvironmentDomain}'
            }
            {
              name: 'Apis_PhrasesApi_BaseUrl'
              value: 'https://${phrasesApiName}.${containerAppsEnvironmentDomain}'
            }
          ]
        }
      ]
      scale: {
        minReplicas: 1
        maxReplicas: 1
      }
    }
    configuration: {
      activeRevisionsMode: 'single'
      ingress: {
        external: true
        targetPort: 80
      }
    }
  }
}
