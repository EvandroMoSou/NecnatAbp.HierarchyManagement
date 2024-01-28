import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class HierarchyManagementService {
  apiName = 'HierarchyManagement';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/HierarchyManagement/sample' },
      { apiName: this.apiName }
    );
  }
}
