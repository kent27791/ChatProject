import { Routes } from '@angular/router';

import { AdminLayoutComponent } from './layouts/admin/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth/auth-layout.component';

export const AppRoutes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      {
        path: '',
        loadChildren: './dashboard/dashboard.module#DashboardModule'
      },
      {
        path: 'security',
        loadChildren: './security/security.module#SecurityModule'
      },
      {
        path: 'datatable',
        loadChildren: './datatable/datatable.module#DatatableModule'
      }
    ]
  },

  {
    path: '',
    component: AuthLayoutComponent,
    children: [
      {
        path: 'authentication',
        loadChildren: './authentication/authentication.module#AuthenticationModule'
      },
      {
        path: 'error',
        loadChildren: './error/error.module#ErrorModule'
      },
      {
        path: 'landing',
        loadChildren: './landing/landing.module#LandingModule'
      }
    ]
  },
  
  {
    path: '**',
    redirectTo: 'error/404'
  }
];

