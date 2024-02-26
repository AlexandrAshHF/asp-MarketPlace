import React, {useState} from 'react';
import classes from "./styles/AuthForm.module.css"
import AuthButton from '../../UI/Buttons/Auth/AuthButton'
import AuthInput from '../../UI/Inputs/Auth/AuthInput';

function LoginForm() {

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [errorMessege, setError] = useState('');

  return (
    <form className={classes.loginForm}>
      <label className={classes.headForm}>Authorization</label>

      <AuthInput type='email' placeholder='Email'
      onChange = { e => setEmail(e.target.value) }/>

      <AuthInput type='password' placeholder='Password' maxLength="24"
      onChange = { e => setPassword(e.target.value) }/>

      <label className={classes.errorMessege}>{errorMessege}</label>

      <div className={classes.submitBlock}>
        <AuthButton>LogIn</AuthButton>
        <a href='https://github.com/AlexandrAshHF/asp-MarketPlace.git' className={classes.toRegisterText}>Don't have an account?</a>
      </div>
    </form>
  );
}
  
export default LoginForm;