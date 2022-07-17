import { useState } from "react";
import LoginForm from "../components/LoginForm";
import RegisterForm from "../components/RegisterForm";
import OAuth from "../components/OAuth";
import {upVariants} from "../animations";
import { motion } from "framer-motion";

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import '../styles/LoginPage.css';
import logoIcon from '../images/logo.png';
import '../styles/Global.scss'

export interface Props {

}

enum State {
    Login,
    Register
}

function LoginPage(props: Props) {
    const [state, setState] = useState(State.Login);
    
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'} className={'layout'}>

        <img src={logoIcon} className="logoIcon"/>

        <Container className="selector">
            <button type={"button"} className={state == State.Login ? 'select_button active' : 'select_button'} onClick={() => setState(State.Login)}>Войти</button>
            <button type={"button"} className={state == State.Register ? 'select_button active' : 'select_button'} onClick={() => setState(State.Register)}>Зарегистрироваться</button>
        </Container>

        {state == State.Login && <LoginForm/>}
        {state == State.Register && <RegisterForm/>}
        <OAuth/>
    </motion.div>
}

export default LoginPage;