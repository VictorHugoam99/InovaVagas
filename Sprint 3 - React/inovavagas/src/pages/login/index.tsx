import React, { useState } from 'react';
import Input from '../../components/input/index';
import imgUSenaiInova from '../../assets/images/senaiInova.png';
import './style.css';
import {Link, useHistory} from 'react-router-dom';
import ButtonFull from '../../components/button/index';
import '../../assets/styles/global.css'
import {parseJwt} from '../../services/auth';

function Login() {
    let history = useHistory()

    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    const login = () => {
        const infoLogin = {
            email: email,
            senha: senha
        }

        fetch('http://localhost:5000/api/Login', {
            method: 'POST',
            body: JSON.stringify(infoLogin),
            headers:{
                'content-type':'application/json'
            }
        })
        .then(response => response.json())
        .then(data => {
            if(data.token !== undefined)
            {
                localStorage.setItem('token', data.token);
                if(parseJwt().Role === 'Administrador')
                {
                    history.push('/admin')
                }

                if(parseJwt().Role === 'Empresa')
                {
                    history.push('/empresa')
                }
                
                if(parseJwt().Role === 'Aluno')
                {
                    history.push('/aluno')
                }
            }
            else
            {
                alert('Senha ou Email incorretos')
            }
        })
        .catch(e => console.error(e));
    };

    return(
        <div className='login'>
            <div className="content">
                <h1>Bem-Vindx!</h1>
                <form className='formulario' onSubmit={e=>{
                    e.preventDefault();
                    login();
                }}>
                    <Input name='email' classCSS='input-placeholder' placeholder='Email' type='email' onChange={e=>setEmail(e.target.value)}/>
                    <Input name='password' classCSS='input-placeholder' placeholder='Senha' type='password' onChange={e=>setSenha(e.target.value)}/><br/>
                    <br/>
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