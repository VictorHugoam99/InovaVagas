import React, { useState } from 'react';
import Input from '../../components/input/index';
import imgUSenaiInova from '../../assets/images/senaiInova.png';
import './style.css';
import { Link, useHistory } from 'react-router-dom';
import ButtonFull from '../../components/button/index';
import '../../assets/styles/global.css'

function AlunoCadastro() {
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

    return (
        <div className='alunoCadastro'>
            <div className="content">
                <h1>Cadastro</h1>
                <form className='formulario'>
                    <Input name='nome' classCSS='input-placeholder' placeholder='Nome Completo' type='text' required />
                    <div className='row1'>
                        <Input name='dataNasc' classCSS='input-placeholder' placeholder='Date de Nascimento' type='date' required />
                        {/* implementar as opções do select */}
                        <Input name='genero' classCSS='input-select' placeholder='Gênero' type='select' required />
                    </div>
                    <Input name='tituloPerfil' classCSS='input-placeholder' placeholder='Título do Perfil' type='text' required />
                    <div className="row2">
                        <Input name='cpf' classCSS='input-placeholder' placeholder='CPF' type='text' maxLength={13} required />
                        <Input name='numeroMatricula' classCSS='input-placeholder' placeholder='Número de Matrícula' type='number' required />
                    </div>
                    <Input name='situacaoEmprego' classCSS='input-select' placeholder='Situação de Empregabilidade' type='select' />
                    <Input name='curso' classCSS='input-select' placeholder='Curso' type='select' required />
                    <Input name='emailContato' classCSS='input-placeholder' placeholder='Email Para Contato' type='email' required />
                    <Input name='endereco' classCSS='input-placeholder' placeholder='Endereço' type='text' />
                    <Input name='telefone' classCSS='input-placeholder' placeholder='Telefone' type='text' />
                    <Input name='celular' classCSS='input-placeholder' placeholder='Celular' type='text' />
                    <Input name='email' classCSS='input-placeholder' placeholder='Email' type='email' />
                    <Input name='senha' classCSS='input-password' placeholder='Senha' type='password' />
                    <Input name='senha' classCSS='input-password' placeholder='Confirmar Senha' type='password' />

                    <div className="botoes">
                        <ButtonFull name='Cadastrar' tamanho='lg' />
                        <ButtonFull name='Cancelar' variante='outline-danger' tamanho='lg' />
                    </div>
                </form>
            </div>

            <div className="logos">
                <img src={imgUSenaiInova} />
                <h1>Bem-Vindx</h1>
                <h2>Aqui seu objetivo se inova!</h2>
                <p>Informe seus dados ao lado e desfrute da melhor ferramenta de vagas!</p>
            </div>
        </div>
    );
}

export default AlunoCadastro;