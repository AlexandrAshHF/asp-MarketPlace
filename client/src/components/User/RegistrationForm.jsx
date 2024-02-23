import React from 'react';
import classes from "./styles/AuthForm.module.css"
import AuthButton from '../../UI/Buttons/Auth/AuthButton'
import AuthInput from '../../UI/Inputs/Auth/AuthInput';

function RegistrationForm({errorMessege}) {
    return (
      <form className={classes.loginForm}>
        <label className={classes.headForm}>Registration</label>

        <AuthInput type='email' placeholder='Email'/>
        <AuthInput type='text' placeholder='Username' maxLength="24"/>
        <AuthInput type='password' placeholder='Password' maxLength="24"/>
        <AuthInput type='password' placeholder='Repeat password' maxLength="24"/>

        <label className={classes.errorMessege}>{errorMessege}</label>

        <div className={classes.submitBlock}>
          <AuthButton>SignUp</AuthButton>
          <a href='https://github.com/AlexandrAshHF/asp-MarketPlace.git' className={classes.toRegisterText}>Already have an account?</a>
        </div>
      </form>
    );
  }
  
  export default RegistrationForm;