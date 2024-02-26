import React, {useState} from 'react';
import classes from "./styles/AuthForm.module.css"
import AuthButton from '../../UI/Buttons/Auth/AuthButton'
import AuthInput from '../../UI/Inputs/AuthInput';

function RegistrationForm() {
  
  const [email, setEmail] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [repeatPassword, setRepeatPass] = useState('');
  const [errorMessege, setError] = useState('');

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
        <AuthButton>SignUp</AuthButton>
        <a href='https://github.com/AlexandrAshHF/asp-MarketPlace.git' 
        className={classes.toRegisterText}>Already have an account?</a>
      </div>
    </form>
  );
}
  
export default RegistrationForm;