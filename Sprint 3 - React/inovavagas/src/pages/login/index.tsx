import React, { useState } from 'react';
import Input from '../../components/input/index';
import imgUSenaiInova from '../../assets/images/senaiInova.png';
import './style.css';
import { Link, useHistory } from 'react-router-dom';
import ButtonFull from '../../components/button/index';
import '../../assets/styles/global.css'
import { parseJwt } from '../../services/auth';

function Login() {
    let history = useHistory();

    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    const login = () => {
        const infoLogin = {
            email: email,
            senha: senha
        };

        fetch('http://localhost:5000/api/login', {
            method: 'POST',
            body: JSON.stringify(infoLogin),
            headers: {
                'content-type':'application/json'
            }
        })
            .then(resp => resp.json())
            .then(data =>{
                if (data.value.token != undefined) 
                {
                    localStorage.setItem('token-inova', data.value.token)
                    
                    if (parseJwt().Role === 'Administrador')
                    {
                        history.push('/admin');
                    }
                    if (parseJwt().Role === 'Empresa') 
                    {
                        history.push('/empresa');
                    }
                    if (parseJwt().Role === 'Aluno') 
                    {
                        history.push('/aluno');
                    }
                }
                else {
                    alert('Email ou senha incorretos');
                }
            })
            .catch(e => console.error(e));
    };

    return (
        <div className='login'>
            <div className="content">
                <h1>Bem-Vinde!</h1>
                <form className='formulario' onSubmit={event => {
                    event.preventDefault();
                    login();
                }}>
                    <input name='email' placeholder='Email' type='text'  onChange={event => setEmail(event.target.value)} />
                    <input name='password' placeholder='Senha' type='password' onChange={event => setSenha(event.target.value)} /><br />
                    <input name='Entrar' type='submit'/>
                </form>
                <Link to='/selecaoCadastro' className='link'>Não tem conta? Cadastre-se!</Link>
            </div>

            <div className="logos">
                <img src={imgUSenaiInova} />
            </div>
        </div>
    );
}

export default Login;