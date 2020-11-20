import React, { useEffect, useState } from 'react';
import Input from '../../components/input/index';
import imgUSenaiInova from '../../assets/images/senai_Inova.png';
import './style.css';
import { Link, useHistory } from 'react-router-dom';
import ButtonFull from '../../components/button/index';
import '../../assets/styles/global.css';
import { parseJwt } from '../../services/auth';

function AlunoCadastro() {
    const history = useHistory();

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

    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [endereco, setEndereco] = useState('');
    const [telefone, setTelefone] = useState('');
    const [celular, setCelular] = useState('');
    const [emailContato, setEmailContato] = useState('');

    // useEffect(() => {

    // }, []);

    const cadastrar = () => {
        const form = {
            nome: nome,
            cpf: cpf,
            rg: rg,
            numeroMatricula: numeroMatricula,
            dataNasc: dataNasc,
            tituloPerfil: tituloPerfil,
            empregado: false,
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

        fetch('http://localhost:5000/api/Aluno', {
            method: 'POST',
            body: JSON.stringify(form),
            headers: {
                'content-type': 'application/json',
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => {
                if (resp.status === 200) {
                    alert('Aluno cadastrado com sucesso!');
                    login();
                }
                else {
                    alert('Houve um erro no cadastro do usuário')
                }
            })
            .catch(err => console.error(err));
    };

    const login = () => {
        const infoLogin = {
            email: email,
            senha: senha
        };

        fetch('http://localhost:5000/api/login', {
            method: 'POST',
            body: JSON.stringify(infoLogin),
            headers: {
                'content-type': 'application/json'
            }
        })
            .then(resp => resp.json())
            .then(data => {
                if (data.value.token != undefined) {
                    localStorage.setItem('token-inova', data.value.token)

                    if (parseJwt().Role === 'Administrador') {
                        history.push('/admin');
                    }
                    if (parseJwt().Role === 'Empresa') {
                        history.push('/empresa');
                    }
                    if (parseJwt().Role === 'Aluno') {
                        history.push('/aluno');
                    }
                }
                else {
                    alert('Houve um erro no login');
                }
            })
            .catch(e => console.error(e));
    };

    useEffect(() => {
        listargenero();
        listarcurso();
    }, []);

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
                console.log('oq' + generos);
            })
            .catch(err => console.error(err));
    }

    return (
        <div className='alunoCadastro'>
            <div className="content">
                <h1>Cadastro</h1>

                <div className="titleHead">
                    <h2 className="aluno">Aluno</h2>
                    <Link to='/eCadastro' className='linkEmpresa'><h2 className="empresa">Empresa</h2></Link>
                </div>

                <form className='formulario' onSubmit={event => {
                    event.preventDefault();
                    cadastrar();
                }}>

                    <h3>Informações Gerais</h3>
                    <Input name='nome' placeholder='Nome Completo' type='text' required onChange={ev => setNome(ev.target.value)} />

                    <div className='row1'>
                        <Input name='dataNasc' placeholder='Date de Nascimento' type='date' onChange={e => setDataNasc(e.target.value)} required />
                    </div>

                    <select name='genero' value={idGenero} placeholder='Gênero' onChange={e => setIdGenero(e.target.value)} required>
                        <option value='0' disabled >Selecione o seu Gênero</option>
                        {
                            generos.map((item: any) => {
                                return <option key={item.idGenero} value={item.idGenero}>{item.nomeGenero}</option>
                            })
                        }
                    </select>

                    <Input name='tituloPerfil' placeholder='Título do Perfil' type='text' onChange={e => setTituloPerfil(e.target.value)} required />

                    <div className="row2">
                        <Input name='cpf' placeholder='CPF' type='text' minLength={11} maxLength={11} onChange={e => setCpf(e.target.value)} required />
                        <Input name='numeroMatricula' placeholder='Número de Matrícula' type='text' minLength={8} maxLength={8} onChange={e => setNumeroMatricula(e.target.value)} required />
                    </div>

                    <Input name='rg' placeholder='RG' type='text' minLength={9} maxLength={9} onChange={e => setRg(e.target.value)} required />
                    {/* <Input name='situacaoEmprego' placeholder='Situação de Empregabilidade' type='select' onChange={e => setEmpregado(e.target.value)} /> */}

                    {/* select */}
                    <select name='curso' placeholder='Curso' value={idCurso} onChange={e => setIdCurso(e.target.value)} required>
                        <option value='0' disabled >Selecione o seu Curso</option>
                        {
                            cursos.map((item: any) => {
                                return <option key={item.IdCurso} value={item.idCurso}>{item.nomeCurso}</option>
                            })
                        }
                    </select>

                    <h3>Informações Para Contato</h3>
                    <Input name='emailContato' placeholder='Email Para Contato' type='email' onChange={e => setEmailContato(e.target.value)} required />
                    <Input name='endereco' placeholder='Endereço' type='text' onChange={e => setEndereco(e.target.value)} />

                    <div className="row3">
                        <Input name='telefone' placeholder='Telefone' type='text' minLength={10} maxLength={10} onChange={e => setTelefone(e.target.value)} />
                        <Input name='celular' placeholder='Celular' type='text' minLength={11} maxLength={11} onChange={e => setCelular(e.target.value)} />
                    </div>

                    <h3>Informações Para a Conta</h3>
                    <Input name='email' placeholder='Email' type='email' onChange={e => setEmail(e.target.value)} />

                    <div className="row4">
                        <Input name='senha' placeholder='Senha' type='password' onChange={e => setSenha(e.target.value)} />
                        <Input name='senhaConfirma' placeholder='Confirmar Senha' type='password' />
                    </div>

                    <div className="botoes">
                        <ButtonFull name='Cadastrar' />
                        <Link to='/selecaoCadastro'><ButtonFull name='Cancelar' /></Link>
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


export default AlunoCadastro;