import React, {useState} from 'react';
import { useNavigate } from 'react-router-dom';
import classes from "./styles/AuthForm.module.css"
import AuthButton from '../../UI/Buttons/Auth/AuthButton'
import AuthInput from '../../UI/Inputs/AuthInput';

function LoginForm() {

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [errorMessege, setError] = useState('');

  const navigate = useNavigate();
  

  async function authButtonClick(e){
    e.preventDefault();
    console.log(email + ' ' + password);
    console.log(JSON.stringify({email, password}));

    try{
      let response = await fetch('https://localhost:7004/Account/Login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({email, password}),
      });
  
      if(response.ok){
        let token = await response.text();
        console.log(`Bearer ${token}`);
        localStorage.setItem("Authorization", `Bearer ${token}`)
        navigate('Products/ProductList', {replace: true});
      }

      else{
        const errorMessege = await response.json();
        setError(errorMessege);
        console.log(errorMessege);
      }
    }
    catch(error){
      console.log(error);
    }
  }

  return (
    <form className={classes.loginForm}>
      <label className={classes.headForm}>Authorization</label>

      <AuthInput type='email' placeholder='Email'
      onChange = { e => setEmail(e.target.value) }/>

      <AuthInput type='password' placeholder='Password' maxLength="24"
      onChange = { e => setPassword(e.target.value) }/>

      <label className={classes.errorMessege}>{errorMessege}</label>

      <div className={classes.submitBlock}>
        <AuthButton onClick={authButtonClick}>LogIn</AuthButton>
        <a href='https://github.com/AlexandrAshHF/asp-MarketPlace.git' className={classes.toRegisterText}>Don't have an account?</a>
      </div>
    </form>
  );
}
  
export default LoginForm;