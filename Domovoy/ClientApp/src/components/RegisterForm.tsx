import {ChangeEvent, FormEvent, useEffect, useState} from "react";
import { useNavigate } from "react-router-dom";
import {AuthService, LoginModel, RegisterModel} from "../api";
import { ValidationProblemDetails } from "../models/ValidationProblemDetails";
import {useAuth} from "./AuthProvider";

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import '../styles/LoginForm.css';
import loginIcon from '../images/loginIcon.svg';
import passwordIcon from '../images/passwordIcon.svg';
import emailIcon from '../images/emailIcon.svg';

export interface Props {

}

function LoginForm(props: Props) {
    const auth = useAuth()
    const navigate = useNavigate()
    const [registerModel, setRegisterModel] = useState<RegisterModel>({email: "", password: "", username: "", fio: "", rePassword: ""});
    const [errors, setErrors] = useState<ValidationProblemDetails>();

    useEffect(() => {
        if (auth.isAuthenticated) navigate("/", {replace: true})
    }, [auth.isAuthenticated])

    const setName = (event: ChangeEvent<HTMLInputElement>) => {
        setRegisterModel({...registerModel, fio: event.target.value});
    }
    
    const setUsername = (event: ChangeEvent<HTMLInputElement>) => {
        setRegisterModel({...registerModel, username: event.target.value});
    }
    
    const setEmail = (event: ChangeEvent<HTMLInputElement>) => {
        setRegisterModel({...registerModel, email: event.target.value});
    }
    
    const setPassword = (event: ChangeEvent<HTMLInputElement>) => {
        setRegisterModel({...registerModel, password: event.target.value});
    }

    const setRePassword = (event: ChangeEvent<HTMLInputElement>) => {
        setRegisterModel({...registerModel, rePassword: event.target.value});
    }
    
    const register = (event: FormEvent) => {
        event.preventDefault()
        if (auth.token) auth.setToken(null)
        AuthService.postApiAuthRegister(registerModel).then(() => {
            AuthService.postApiAuthLogin(registerModel).then(response => {
                auth.setToken(response.token);
            }).catch(error => {
                setErrors(JSON.parse(error.body));
            });
        }).catch((error) => {
            setErrors(JSON.parse(error.body));
        })
    }
    
    return <form onSubmit={register}>
        {errors && <div>{Object.entries(errors.errors).map((([f, e]) => e.map(e => <p>{e}</p>)))}</div>}
        <Container className="no_padding">
            <input className="inputData" onChange={setName} value={registerModel.fio} placeholder={"ФИО"} name="name" required/>
            <img src={loginIcon} className="inputIcons"/>
            <br/>
            <input className="inputData" onChange={setUsername} value={registerModel.username} placeholder={"Логин"} name="username" required/>
            <img src={loginIcon} className="inputIcons"/>
            <br/>
            <input className="inputData" onChange={setEmail} value={registerModel.email} placeholder={"Почта"} type={"email"} required/>
            <img src={emailIcon} className="inputIcons"/>
            <br/>
            <input className="inputData" onChange={setPassword} value={registerModel.password} placeholder={"Пароль"} type={"password"} required autoComplete={"new-password"}/>
            <img src={passwordIcon} className="inputIcons"/>
            <br/>
            <input className="inputData" onChange={setRePassword} value={registerModel.rePassword} placeholder={"Повторите пароль"} type={"password"} required autoComplete={"new-password"}/>
            <img src={passwordIcon} className="inputIcons"/>
            <br/>
            <button type={"submit"} className="loginAccount">Зарегистрироваться</button>
        </Container> 
    </form>
}

export default LoginForm;