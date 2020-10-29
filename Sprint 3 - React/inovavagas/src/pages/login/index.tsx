import React, { useState } from 'react';
import Input from '../../components/input/index';
import imgUSenaiInova from '../../assets/images/senaiInova.png';
import './style.css';
import {Link, useHistory} from 'react-router-dom';
import ButtonFull from '../../components/button/index';
import '../../assets/styles/global.css'

function Login() {
    // let history = useHistory();

    // const [email, setEmail] = useState('');
    // const [senha, setSenha] = useState('');

    // const login = () => {
    //     const infoLogin = {
    //         email: email,
    //         senha: senha
    //     };

    //     //fetch()

    // };

    return(
        <div className='login'>
            <div className="content">
                <h1>Bem-Vindx!</h1>
                <form className='formulario'>
                    <Input name='email' classCSS='input-placeholder' placeholder='Email' type='email'/>
                    <Input name='password' classCSS='input-row' placeholder='Senha' type='password'/>
                    <ButtonFull name='Entrar' tamanho='lg'/>
                </form>
                <Link to='/selecaoCadastro' className='link'>Não tem conta? Cadastre-se!</Link>
            </div>

            <div className="logos">
                <img src={imgUSenaiInova}/>
            </div>
        </div>
    );
}

export default Login;