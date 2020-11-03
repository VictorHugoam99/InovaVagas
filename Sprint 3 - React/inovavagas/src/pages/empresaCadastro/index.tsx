import React, { useState } from 'react';
import Input from '../../components/input/index';
import imgUSenaiInova from '../../assets/images/senaiInova.png';
import './style.css';
import { Link, useHistory } from 'react-router-dom';
import ButtonFull from '../../components/button/index';
import '../../assets/styles/global.css'

function EmpresaCadastro() {
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
        <div className='empresaCadastro'>
            <div className="content">
                <h1>Cadastro</h1>

                <div className="titleHead">
                    <Link to='/aCadastro' className='linkEmpresa'><h2 className="aluno">Aluno</h2></Link>
                    <h2 className="empresa">Empresa</h2>
                </div>

                <form className='formulario'>

                    <h3>Informações Gerais</h3>
                    <Input name='razaoSocial' classCSS='input-placeholder' placeholder='Razão Social' type='text' required />

                    <Input name='nomeFantasia' classCSS='input-placeholder' placeholder='Nome Fantasia' type='text' required />

                    <Input name='atuacao' classCSS='input-select' placeholder='Atuação' type='text' required />
                    <div className="row1">
                        <Input name='sede' classCSS='input-placeholder' placeholder='Sede' type='text' required />
                        <Input name='segmento' classCSS='input-placeholder' placeholder='Segmento' type='text' required />
                    </div>

                    <div className="row2">
                        <Input name='cnpj' classCSS='input-placeholder' placeholder='CNPJ' type='text' maxLength={13} required />
                        <Input name='CNAE' classCSS='input-placeholder' placeholder='CNAE' type='text' maxLength={13} required />
                    </div>

                    <h3>Informações Para Contato</h3>
                    <Input name='emailContato' classCSS='input-placeholder' placeholder='Email Para Contato' type='email' required />
                    <Input name='endereco' classCSS='input-placeholder' placeholder='Endereço' type='text' />
                    <div className="row3">
                        <Input name='telefone' classCSS='input-placeholder' placeholder='Telefone' type='text' />
                        <Input name='celular' classCSS='input-placeholder' placeholder='Celular' type='text' />
                    </div>
                    <Input name='nomeResponsavel' classCSS='input-placeholder' placeholder='Nome da Pessoa Responsável pelos Empregos' type='text' />

                    <h3>Informações Para a Conta</h3>
                    <Input name='email' classCSS='input-placeholder' placeholder='Email' type='email' />
                    <div className="row4">
                        <Input name='senha' classCSS='input-password' placeholder='Senha' type='password' />
                        <Input name='senhaConfirma' classCSS='input-password' placeholder='Confirmar Senha' type='password' />
                    </div>

                    <div className="botoes">
                        <ButtonFull name='Cadastrar' tamanho='lg' />
                        <Link to='/selecaoCadastro'><ButtonFull name='Cancelar' variante='outline-danger' tamanho='lg' /></Link>
                    </div>
                </form>
            </div>

            <div className="logos">
                <img src={imgUSenaiInova} />
                <h1>Bem-Vindx</h1>
                <h2>Aqui Seu Objetivo Se Inova!</h2>
                <p>Informe seus dados ao lado e desfrute da melhor ferramenta de vagas!</p>
            </div>
        </div>
    );
}

export default EmpresaCadastro;