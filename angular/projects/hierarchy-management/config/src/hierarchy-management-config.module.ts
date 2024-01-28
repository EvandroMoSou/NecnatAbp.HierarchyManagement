import { ModuleWithProviders, NgModule } from '@angular/core';
import { HIERARCHY_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class HierarchyManagementConfigModule {
  static forRoot(): ModuleWithProviders<HierarchyManagementConfigModule> {
    return {
      ngModule: HierarchyManagementConfigModule,
      providers: [HIERARCHY_MANAGEMENT_ROUTE_PROVIDERS],
    };
  }
}
