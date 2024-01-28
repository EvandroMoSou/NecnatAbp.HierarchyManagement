import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'HierarchyManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44367/',
    redirectUri: baseUrl,
    clientId: 'HierarchyManagement_App',
    responseType: 'code',
    scope: 'offline_access HierarchyManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44367',
      rootNamespace: 'NecnatAbp.HierarchyManagement',
    },
    HierarchyManagement: {
      url: 'https://localhost:44392',
      rootNamespace: 'NecnatAbp.HierarchyManagement',
    },
  },
} as Environment;
