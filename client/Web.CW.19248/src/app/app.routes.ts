import { Routes } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { AddComponent } from './components/add/add.component';
import { EditComponent } from './components/edit/edit.component';
import { ViewComponent } from './components/view/view.component';

export const routes: Routes = [
    {path: '', redirectTo: 'contacts', pathMatch: 'full'},
    {path: 'contacts', component: MainComponent},
    {path: 'contacts/add', component: AddComponent},
    {path: 'contacts/edit/:id', component: EditComponent},
    {path: 'contacts/view/:id', component: ViewComponent},
];
