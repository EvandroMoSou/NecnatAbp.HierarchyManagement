import { Component, OnInit } from '@angular/core';
import { HierarchyManagementService } from '../services/hierarchy-management.service';

@Component({
  selector: 'lib-hierarchy-management',
  template: ` <p>hierarchy-management works!</p> `,
  styles: [],
})
export class HierarchyManagementComponent implements OnInit {
  constructor(private service: HierarchyManagementService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
