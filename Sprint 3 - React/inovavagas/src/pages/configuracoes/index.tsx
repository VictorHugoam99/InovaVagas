import React, { useEffect, useState } from 'react';
import Header from '../../components/header';

import './style.css';
import '../../assets/styles/global.css';

import imgConfig from '../../assets/images/config_Cinza.png';
import Input from '../../components/input';
import Button from 'react-bootstrap/esm/Button';
import ButtonFull from '../../components/button';
import { Link, useHistory } from 'react-router-dom';
import { parseJwt } from '../../services/auth';
import { Modal } from 'react-bootstrap';
import HomeAluno from '../homeAluno';
import HomeEmpresa from '../homeEmpresa';

function Configuracao() {
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

    // Aluno
    const [nome, setNome] = useState('');
    const [cpf, setCpf] = useState('');
    const [rg, setRg] = useState('');
    const [numeroMatricula, setNumeroMatricula] = useState('');
    const [dataNasc, setDataNasc] = useState('');
    const [tituloPerfil, setTituloPerfil] = useState('');
    const [empregado, setEmpregado] = useState('');

    const [idGenero, setIdGenero] = useState('0');
    const [genero, setGenero] = useState('');
    const [generos, setGeneros] = useState([]);

    const [idCurso, setIdCurso] = useState('0');
    const [curso, setCurso] = useState('');
    const [cursos, setCursos] = useState([]);

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const history = useHistory();

    useEffect(() => {
        listargenero();
        listarcurso();
    }, []);

    const editarAluno = (idAluno: number) => {
        const form = {
            nome: nome,
            cpf: cpf,
            rg: rg,
            numeroMatricula: numeroMatricula,
            dataNasc: dataNasc,
            tituloPerfil: tituloPerfil,
            idCurso: idCurso,
            idGenero: idGenero,
            idUsuarioNavigation: {
                email: email,
                senha: senha,
                endereco: endereco,
                telefone: telefone,
                celular: celular,
                emailContato: emailContato
            }
        }
        console.log(form);

        fetch('http://localhost:5000/api/Aluno/' + idAluno, {
            method: 'PUT',
            body: JSON.stringify(form),
            headers: {
                'content-type': 'application/json',
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(response => {
                if (response.status === 200) {
                    alert('Alterações Realizadas com Sucesso')
                    history.push('/aluno');
                }
            })
            .catch(e => { console.error(e) });
    }

    const editarEmpresa = (idEmpresa: number) => {

        const form = {
            razaoSocial: razaoSocial,
            nomeFantasia: nomeFantasia,
            ramoAtuacao: ramoAtuacao,
            tamanhoEmpresa: tamanhoEmpresa,
            cnpj: cnpj,
            cnae: cnae,
            cadastroAprovado: true,
            pessoaResponsavel: pessoaResponsavel,
            idUsuarioNavigation: {
                email: email,
                senha: senha,
                endereco: endereco,
                telefone: telefone,
                celular: celular,
                emailContato: emailContato
            }
        };
        console.log(JSON.stringify(form))

        fetch('http://localhost:5000/api/Empresa/' + idEmpresa, {
            method: 'PUT',
            body: JSON.stringify(form),
            headers: {
                'content-type': 'application/json',
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
            .then(response => {
                if (response.status === 204) {
                    alert('Alterações Realizadas com Sucesso')
                    history.push('/aluno');
                }
            })
            .catch(e => { console.error(e) });
    }


    const listargenero = () => {
        fetch('http://localhost:5000/api/Genero', {
            method: 'GET',
            headers: {
                //Bearer authentication é o token authentication, um Schema para autenticação HTTP 
                //O Bearer identifica recursos protegidos por um OAuth2.
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setGeneros(dados);
                console.log(dados);
                console.log('oq' + generos);
            })
            .catch(err => console.error(err));
    }

    const listarcurso = () => {
        fetch('http://localhost:5000/api/Curso', {
            method: 'GET',
            headers: {
                //Bearer authentication é o token authentication, um Schema para autenticação HTTP 
                //O Bearer identifica recursos protegidos por um OAuth2.
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setCursos(dados);
                console.log(dados);
            })
            .catch(err => console.error(err));
    }

    const configRole = () => {
        if (parseJwt().Role === 'Empresa') {
            return (
                <div className='config'>

                    <div className="content">

                        <form className='formulario' onSubmit={event => {
                            event.preventDefault()
                            editarEmpresa(parseJwt().Id)
                        }}>

                            <h3>Informações Gerais</h3>
                            <Input name='razao' placeholder='Razão Social' type='text' value={razaoSocial} onChange={e => setRazaoSocial(e.target.value)} />

                            <Input name='nome' placeholder='Nome Fantasia' type='text' value={nomeFantasia} onChange={e => setNomeFantasia(e.target.value)} />

                            <Input name='atuacao' placeholder='Atuação' type='text' value={ramoAtuacao} onChange={e => setRamoAtuacao(e.target.value)} />
                            <Input name='tamanhoEmpresa' placeholder='Tamanho da empresa' type='text' value={tamanhoEmpresa} onChange={e => setTamanhoEmpresa(e.target.value)} />

                            <div className="row2config">
                                <Input name='cnpj' placeholder='CNPJ' type='text' maxLength={11} value={cnpj} onChange={e => setCnpj(e.target.value)} />
                                <Input name='CNAE' placeholder='CNAE' type='text' maxLength={7} value={cnae} onChange={e => setCnae(e.target.value)} />
                            </div>

                            <h3>Informações Para Contato</h3>
                            <Input name='emailContato' placeholder='Email Para Contato' type='email' value={emailContato} onChange={e => setEmailContato(e.target.value)} />
                            <Input name='endereco' placeholder='Endereço' type='text' value={endereco} onChange={e => setEndereco(e.target.value)} />
                            <div className="row3config">
                                <Input name='telefone' placeholder='Telefone' maxLength={10} type='text' value={telefone} onChange={e => setTelefone(e.target.value)} />
                                <Input name='celular' placeholder='Celular' maxLength={11} type='text' value={celular} onChange={e => setCelular(e.target.value)} />
                            </div>
                            <Input name='nomeResponsavel' placeholder='Nome da Pessoa Responsável pelos Empregos' type='text' value={pessoaResponsavel} onChange={e => setPessoaResponsavel(e.target.value)} />

                            <h3>Informações Para a Conta</h3>
                            <Input name='email' placeholder='Email' type='email' value={email} onChange={e => setEmail(e.target.value)} />
                            <div className="row4config">
                                <Input name='senha' placeholder='Senha' type='password' value={senha} onChange={e => setSenha(e.target.value)} />
                                <Input name='senhaConfirma' placeholder='Confirmar Senha' type='password' />
                            </div>

                            <div className="botoes">
                                <ButtonFull name='Salvar' tamanho='lg' />
                                <Link to='/empresa'><ButtonFull name='Cancelar' tamanho='lg' /></Link>
                            </div>
                        </form>
                    </div>
                </div>
            );
        }
        else if (parseJwt().Role === 'Aluno') {
            return (
                <div className="content">

                    <form className='formulario' onSubmit={event => {
                        event.preventDefault();
                        editarAluno(parseJwt().Id);
                    }}>

                        <h3>Informações Gerais</h3>
                        <Input name='nome' placeholder='Nome Completo' type='text' value={nome} onChange={ev => setNome(ev.target.value)} />

                        <div className='row1'>
                            <Input name='dataNasc' placeholder='Date de Nascimento' value={dataNasc} type='date' onChange={e => setDataNasc(e.target.value)} />
                        </div>

                        <select name='genero' value={idGenero} placeholder='Gênero' onChange={e => setIdGenero(e.target.value)} >
                            <option value='0' disabled >Selecione o seu Gênero</option>
                            {
                                generos.map((item: any) => {
                                    return <option key={item.idGenero} value={item.idGenero}>{item.nomeGenero}</option>
                                })
                            }
                        </select>

                        <Input name='tituloPerfil' placeholder='Título do Perfil' value={tituloPerfil} type='text' onChange={e => setTituloPerfil(e.target.value)} />

                        <div className="row2config">
                            <Input name='cpf' placeholder='CPF' type='text' minLength={11} value={cpf} maxLength={11} onChange={e => setCpf(e.target.value)} />
                            <Input name='numeroMatricula' placeholder='Número de Matrícula' value={numeroMatricula} type='text' minLength={8} maxLength={8} onChange={e => setNumeroMatricula(e.target.value)} />
                        </div>

                        <Input name='rg' placeholder='RG' type='text' value={rg} minLength={9} maxLength={9} onChange={e => setRg(e.target.value)} />
                        {/* <Input name='situacaoEmprego' placeholder='Situação de Empregabilidade' type='select' onChange={e => setEmpregado(e.target.value)} /> */}

                        {/* select */}
                        <select name='curso' placeholder='Curso' value={idCurso} onChange={e => setIdCurso(e.target.value)} >
                            <option value='0' disabled >Selecione o seu Curso</option>
                            {
                                cursos.map((item: any) => {
                                    return <option key={item.IdCurso} value={item.idCurso}>{item.nomeCurso}</option>
                                })
                            }
                        </select>

                        <h3>Informações Para Contato</h3>
                        <Input name='emailContato' placeholder='Email Para Contato' value={emailContato} type='email' onChange={e => setEmailContato(e.target.value)} />
                        <Input name='endereco' placeholder='Endereço' type='text' value={endereco} onChange={e => setEndereco(e.target.value)} />

                        <div className="row3config">
                            <Input name='telefone' placeholder='Telefone' type='text' value={telefone} minLength={10} maxLength={10} onChange={e => setTelefone(e.target.value)} />
                            <Input name='celular' placeholder='Celular' type='text' value={celular} minLength={11} maxLength={11} onChange={e => setCelular(e.target.value)} />
                        </div>

                        <h3>Informações Para a Conta</h3>
                        <Input name='email' placeholder='Email' type='email' value={email} onChange={e => setEmail(e.target.value)} />

                        <div className="row4config">
                            <Input name='senha' placeholder='Senha' type='password' value={senha} onChange={e => setSenha(e.target.value)} />
                            <Input name='senhaConfirma' placeholder='Confirmar Senha' type='password' />
                        </div>

                        <div className="botoes">
                            <ButtonFull name='Salvar' />
                            <Link to='/aluno'><ButtonFull name='Cancelar' /></Link>
                        </div>
                    </form>
                </div>
            );
        }
    }
    return (
        <div>
            <div className='config'>
                <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />

                <div className='content-config'>
                    <div className="background">
                        <div className="title">
                            <h1>Configuração</h1>
                            <p className="texto" >Edite informações da conta!</p>
                        </div>
                    </div>
                    {configRole()}
                </div>
            </div>
        </div>
    );

}

export default Configuracao;