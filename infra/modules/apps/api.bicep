param location string

param apiName string
param imageName string
param containerAppsEnvironmentId string
param containerAppsEnvironmentDomain string

resource containerApp 'Microsoft.App/containerApps@2022-03-01' = {
  name: apiName
  location: location
  properties: {
    managedEnvironmentId: containerAppsEnvironmentId
    template: {
      containers: [
        {
          name: apiName
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
              name: 'AllowedOrigins'
              value: ['https://app.${containerAppsEnvironmentDomain}']
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
        external: false
        targetPort: 80
        allowInsecure: true
      }
    }
  }
}
