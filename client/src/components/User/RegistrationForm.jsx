import React, {useEffect, useState} from 'react';
import classes from "./styles/AuthForm.module.css"
import AuthButton from '../../UI/Buttons/Auth/AuthButton'
import AuthInput from '../../UI/Inputs/AuthInput';
import { useNavigate } from 'react-router-dom';

function RegistrationForm() {
  
  const [email, setEmail] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [repeatPassword, setRepeatPass] = useState('');
  const [errorMessege, setError] = useState('');
  const navigate = useNavigate();

  async function fetchRegister() {
    let response = await fetch('url', 
    {
      method: 'POST',
      headers:
      {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({email, username, password}),
    });

    if(response.ok)
      navigate('/Account/Login', {replace: true});

    else {
      let data = await response.json();
      setError(data);
    }
  }

  function authClick() {
    if(password != repeatPassword)
      setError('Passwords should be equals')
    else
      fetchRegister();
  }

  return (
    <form className={classes.loginForm}>
      <label className={classes.headForm}>Registration</label>

      <AuthInput type='email' placeholder='Email'
      onChange={ e => setEmail(e.target.value) }/>

      <AuthInput type='text' placeholder='Username' maxLength="24"
      onChange={ e => setUsername(e.target.value) }/>

      <AuthInput type='password' placeholder='Password' maxLength="24"
      onChange={ e => setPassword(e.target.value) }/>

      <AuthInput type='password' placeholder='Repeat password' maxLength="24"
      onChange={ e => setRepeatPass(e.target.value) }/>

      <label className={classes.errorMessege}>{errorMessege}</label>

      <div className={classes.submitBlock}>
        <AuthButton onClick={() => authClick()}>SignUp</AuthButton>
        <a href='https://github.com/AlexandrAshHF/asp-MarketPlace.git' 
        className={classes.toRegisterText}>Already have an account?</a>
      </div>
    </form>
  );
}
  
export default RegistrationForm;