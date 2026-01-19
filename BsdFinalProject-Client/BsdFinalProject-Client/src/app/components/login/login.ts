import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoginService } from '../../Services/login-service';
import { ChangeDetectorRef } from '@angular/core';
import {jwtDecode, JwtPayload} from 'jwt-decode';
import { FormsModule } from '@angular/forms';
import { AutoComplete } from 'primeng/autocomplete';
import { FloatLabel } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
@Component({
  selector: 'app-login', 
  imports: [FormsModule, FloatLabel, InputTextModule],
  templateUrl: './login.html',
  styleUrls: ['./login.scss'],
 
})
export class LoginComponent {
   loginSrv: LoginService = inject(LoginService);
   ref = inject(ChangeDetectorRef)
   router= inject(Router);
   email: string = "";
   password: string = ""; 
   role: string = "";
  
   login() {
    alert("1התחברות במערכת")
    try{
      alert("2התחברות במערכת")
      this.loginSrv.login({email:this.email,password:this.password}).subscribe({
        error: (error) => {
          alert("התחברות נכשלה")
          console.error('Login error:', error);
        },
        next: (response) => {
          alert("התחברות הצליחה")
          console.log('Login successful:', response);
          localStorage.setItem('token', response);
          this.ref.detectChanges();
          const decoded: any= jwtDecode(response);
          this.role = decoded.role || '';
          console.log(this.role)
          if(this.role=="User")
            this.router.navigate(['user/home'])
          if(this.role=="Manager")
            this.router.navigate(['manager/home'])
          else
           alert("משתמש לא מזוהה עבור להרשמה")
        },
        

        //this.router.navigate(['/home']);
      });
    } catch (error) {
      //הוספת הודעה למשתמש
      alert("משתמש לא מזוהה עבור להרשמה")
      console.error('Login error:', error);
    }

   }

}

