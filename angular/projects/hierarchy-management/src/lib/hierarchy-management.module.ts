import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { HierarchyManagementComponent } from './components/hierarchy-management.component';
import { HierarchyManagementRoutingModule } from './hierarchy-management-routing.module';

@NgModule({
  declarations: [HierarchyManagementComponent],
  imports: [CoreModule, ThemeSharedModule, HierarchyManagementRoutingModule],
  exports: [HierarchyManagementComponent],
})
export class HierarchyManagementModule {
  static forChild(): ModuleWithProviders<HierarchyManagementModule> {
    return {
      ngModule: HierarchyManagementModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<HierarchyManagementModule> {
    return new LazyModuleFactory(HierarchyManagementModule.forChild());
  }
}
