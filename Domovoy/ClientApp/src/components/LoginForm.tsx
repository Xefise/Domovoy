import {ChangeEvent, FormEvent, useEffect, useState} from "react";
import { useNavigate } from "react-router-dom";
import {AuthService, LoginModel} from "../api";
import { ValidationProblemDetails } from "../models/ValidationProblemDetails";
import {useAuth} from "./AuthProvider";

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import '../styles/LoginForm.css';
import loginIcon from '../images/loginIcon.svg';
import passwordIcon from '../images/passwordIcon.svg';

export interface Props {

}

function LoginForm(props: Props) {
    const auth = useAuth()
    const navigate = useNavigate()
    const [loginModel, setLoginModel] = useState<LoginModel>({password: "", username: ""});
    const [errors, setErrors] = useState<ValidationProblemDetails>();
    
    const setUsername = (event: ChangeEvent<HTMLInputElement>) => {
        setLoginModel({...loginModel, username: event.target.value});
    }
    
    const setPassword = (event: ChangeEvent<HTMLInputElement>) => {
        setLoginModel({...loginModel, password: event.target.value});
    }
    
    useEffect(() => {
        if (auth.isAuthenticated) navigate("/", {replace: true})
    }, [auth.isAuthenticated])
    
    const login = (event: FormEvent) => {
        event.preventDefault()
        if (auth.token) auth.setToken(null)
        AuthService.postApiAuthLogin(loginModel).then(response => {
            auth.setToken(response.token);
        }).catch(error => {
            setErrors(JSON.parse(error.body));
        });
    }
    
    return <>
        <form className="Form" onSubmit={login}>
        {errors && <div>{Object.entries(errors.errors).map((([f, e]) => e.map(e => <p>{e}</p>)))}</div>}
            <Container className="no_padding">
                <input className="inputData" onChange={setUsername} value={loginModel.username} placeholder={"Логин"} required/>
                <img src={loginIcon} className="inputIcons"/>
                <br/>
                <input className="inputData" onChange={setPassword} value={loginModel.password} placeholder={"Пароль"} type={"password"} required autoComplete={"current-password"}/>
                <img src={passwordIcon} className="inputIcons"/>
                <br/>
                <button type={"submit"} className="loginAccount">Войти</button>
                <p onClick={() => alert("Вспоминайте!")}>Забыли пароль?</p>
            </Container>
        </form>
    </>

   
}

export default LoginForm;