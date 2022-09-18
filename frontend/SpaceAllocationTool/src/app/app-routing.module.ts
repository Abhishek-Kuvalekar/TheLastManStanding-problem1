import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SpaceAllocatorModule } from 'src/space-allocator/space-allocator.module';
import { routes } from './routes';

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    SpaceAllocatorModule
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
