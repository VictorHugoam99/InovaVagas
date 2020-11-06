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

    const [idEmpresa, setIdEmpresa] = useState(0);
    const [empresas, setEmpresas] = useState([]);
    const [email, setEmail] = useState('');
    const [emailContato, setEmailContato] = useState('');
    const [telefone, setTelefone] = useState('');
    const [celular, setCelular] = useState('');
    const [senha, setSenha] = useState('');
    const [endereco, setEndereco] = useState('');
    const [razaoSocial, setRazaoSocial] = useState('');
    const [nomeFantasia, setNomeFantasia] = useState('');
    const [ramoAtuacao, setRamoAtuacao] = useState('');
    const [tamanhoEmpresa, setTamanhoEmpresa] = useState('');
    const [cnpj, setCnpj] = useState('');
    const [cnae, setCnae] = useState('');
    const [pessoaResponsavel, setPessoaResponsavel] = useState('');

    
    
    const salvar = () => {
        
        const urlUsuario = 'http://localhost:5000/api/Usuario/cadastroUsuario';
        
            var idUser = 0;
            const formUsuario = {
                email: email,
                senha: senha,
                imagemPerfil: null,
                endereco: endereco,
                telefone: telefone,
                celular: celular,
                emailContato: emailContato
            };

            fetch(urlUsuario, {
                method: 'POST',
                body: JSON.stringify(formUsuario),
                headers: {
                    'content-type' : 'application/json',
                    // authorization: 'Bearer' + localStorage.getItem('token-inova')
                }
            })
            .then(response => response.json())
            .then(resp => {
                idUser = resp
            })
            .then(() => {
                const urlRequest = 'http://localhost:5000/api/Empresa';
        
            const form = {
                razaoSocial: razaoSocial,
                nomeFantasia: nomeFantasia,
                ramoAtuacao: ramoAtuacao,
                tamanhoEmpresa: tamanhoEmpresa,
                cnpj: cnpj,
                cnae: cnae,
                cadastroAprovado: true,
                pessoaResponsavel: pessoaResponsavel,
                email: email,
                senha: senha,
                imagemPerfil: null,
                endereco: endereco,
                telefone: telefone,
                celular: celular,
                emailContato: emailContato, 
                idUsuario: idUser
            };
            console.log(JSON.stringify(form))

            fetch(urlRequest, {
                method: 'POST',
                body: JSON.stringify(form),
                headers: {
                    'content-type' : 'application/json',
                    // authorization: 'Bearer' + localStorage.getItem('token-inova')
                }
            })
            .then(() => {alert("Empresa cadastrada")})
            })
    }

    return (
        <div className='empresaCadastro'>
            <div className="content">
                <h1>Cadastro</h1>

                <div className="titleHead">
                    <Link to='/aCadastro' className='linkEmpresa'><h2 className="aluno">Aluno</h2></Link>
                    <h2 className="empresa">Empresa</h2>
                </div>

                <form className='formulario' onSubmit={event => {
                        event.preventDefault()
                        salvar()
                }}>

                    <h3>Informações Gerais</h3>
                    <Input name='razaoSocial' placeholder='Razão Social' type='text' required value={razaoSocial} onChange={e => setRazaoSocial(e.target.value)}/>

                    <Input name='nomeFantasia'  placeholder='Nome Fantasia' type='text' required value={nomeFantasia} onChange={e => setNomeFantasia(e.target.value)}/>

                    <Input name='atuacao' placeholder='Atuação' type='text' required value={ramoAtuacao} onChange={e => setRamoAtuacao(e.target.value)}/>
                    <div className="row1">
                        <Input name='tamanhoEmpresa' placeholder='Tamanho da empresa' type='text' value={tamanhoEmpresa} required onChange={e => setTamanhoEmpresa(e.target.value)}/> 
                        {/* <Input name='segmento' classCSS='input-placeholder' placeholder='Segmento' type='text' required /> */}
                    </div>

                    <div className="row2">
                        <Input name='cnpj' placeholder='CNPJ' type='text' maxLength={13} required value={cnpj} onChange={e => setCnpj(e.target.value)}/>
                        <Input name='CNAE' placeholder='CNAE' type='text' maxLength={13} required value={cnae} onChange={e => setCnae(e.target.value)}/>
                    </div>

                    <h3>Informações Para Contato</h3>
                    <Input name='emailContato' placeholder='Email Para Contato' type='email' required value={emailContato} onChange={e => setEmailContato(e.target.value)}/>
                    <Input name='endereco'  placeholder='Endereço' type='text' value={endereco} onChange={e => setEndereco(e.target.value)}/>
                    <div className="row3">
                        <Input name='telefone'  placeholder='Telefone' type='text' value={telefone} onChange={e => setTelefone(e.target.value)}/>
                        <Input name='celular'  placeholder='Celular' type='text' value={celular} onChange={e => setCelular(e.target.value)}/>
                    </div>
                    <Input name='nomeResponsavel'  placeholder='Nome da Pessoa Responsável pelos Empregos' type='text' value={pessoaResponsavel} onChange={e => setPessoaResponsavel(e.target.value)}/>

                    <h3>Informações Para a Conta</h3>
                    <Input name='email'  placeholder='Email' type='email' value={email} onChange={e => setEmail(e.target.value)}/>
                    <div className="row4">
                        <Input name='senha'  placeholder='Senha' type='password' value={senha} onChange={e => setSenha(e.target.value)}/>
                        <Input name='senhaConfirma'  placeholder='Confirmar Senha' type='password' />
                    </div>

                    <div className="botoes">
                        <ButtonFull name='Cadastrar' tamanho='lg' />
                        <Link to='/selecaoCadastro'><ButtonFull name='Cancelar' tamanho='lg' /></Link>
                    </div>
                </form>
            </div>

            <div className="logos">
                <img src={imgUSenaiInova} />
                <h1>Bem-Vinde</h1>
                <h2>Aqui Seu Objetivo Se Inova!</h2>
                <p>Informe seus dados ao lado e desfrute da melhor ferramenta de vagas!</p>
            </div>
        </div>
    );
}

export default EmpresaCadastro;