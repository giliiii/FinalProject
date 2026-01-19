import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// Importing the Login component
import { LoginComponent } from './components/login/login';




@Component({
  selector: 'app-root',
  imports: [RouterOutlet, LoginComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('BsdFinalProject-Client');
}
