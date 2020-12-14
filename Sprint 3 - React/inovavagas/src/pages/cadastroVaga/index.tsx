import React, { useEffect, useState } from 'react';
import ButtonFull from '../../components/button/index';
import './style.css';
import { Link, useHistory } from 'react-router-dom';
// import imgUSenaiInova from '../../assets/images/senai_Inova.png';
import add from '../../assets/images/mais_Cinza.png';
import Footer from '../../components/footer/index';
import Header from '../../components/header/index';
import { parseJwt } from '../../services/auth';

//const [get, set]
function CadastrarVagas() {
    const history = useHistory();

    useEffect(() => {
        listarAreaVaga();
        FormaContratacao();
        empresaFetch(parseJwt().Id);
    }, [])
    const [FormaContratacaomap, setFormaContratacaomap] = useState([]); //Para lista
    const [AreaVagamap, setAreaVagamap] = useState([]);
    const [IdVaga, setIdVaga] = useState(0);
    const [NomeVaga, setNomeVaga] = useState('');
    const [Descricao, setDescricao] = useState('');
    const [Requisitos, setRequisitos] = useState('');
    const [Endereco, setEndereco] = useState('');
    const [NumeroCandidatos, setNumeroCandidatos] = useState(0);
    const [VagaAtiva, setVagaAtiva] = useState('');
    const [DataEncerramento, setDataEncerramento] = useState('');
    const [DataCadastro, setDataCadastro] = useState('');
    const [Salario, setSalario] = useState('');
    const [IdEmpresa, setIdEmpresa] = useState(0);
    const [IdFormaContratacao, setIdFormaContratacao] = useState('0');
    const [IdAreaVaga, setIdAreaVaga] = useState('0');
    const [Candidatura, setCandidatura] = useState('0');

    const queryString = window.location.search;

    const urlParams = new URLSearchParams(queryString);

    const idCadastrar = urlParams.get('id');

    //nao usar use effect pq ele carrega assim q esntrar na pagina
    //chave(api) e valor(react) 
    const Cadastrar = () => {
        const form = {
            nomeVaga: NomeVaga,
            descricao: Descricao,
            requisitos: Requisitos,
            vagaAtiva: true,
            idEmpresa: idCadastrar,
            salario: Salario,
            idFormaContratacao: parseInt(IdFormaContratacao),
            idAreaVaga: parseInt(IdAreaVaga),
        }
        console.log(JSON.stringify(form))
        const url = 'http://localhost:5000/api/Vaga';
        fetch(url, {
            method: 'POST',
            body: JSON.stringify(form),
            headers: {
                'Content-Type': 'application/json',
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
        .then(() => {
            setNomeVaga('');
            setDescricao('');
            setRequisitos('');
            setSalario('');
            setIdFormaContratacao('0');
            setIdAreaVaga('0');
        })
            .then(() => { alert("Tudo certinho") })
            .catch(err => {
                console.error(err); //retornar um erro 
            });
    }
    const FormaContratacao = () => {
        fetch('http://localhost:5000/api/FormaContratacao', {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova'),
                'Content-Type': 'application/json',
            }
        })
            .then(response => response.json())
            .then(dados => {
                setFormaContratacaomap(dados);
                console.log('' + FormaContratacaomap)

            })
            .catch(err => console.error(err));
    }

    const empresaFetch = (id: number) => {
        fetch('http://localhost:5000/api/empresa/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setIdVaga(dados.idVaga);
                console.log(id);
                // localStorage.setItem( 'IdVaga', String(idVaga))
                history.push(`/cadastroVaga?id=${id}`)
            })
            .catch(err => console.error(err));
    }

    const listarAreaVaga = () => {
        fetch('http://localhost:5000/api/AreaVaga', {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova'),
                'Content-Type': 'application/json',
            }
        })
            .then(response => response.json())
            .then(dados => {
                setAreaVagamap(dados);
                console.log('' + AreaVagamap)

            })
            .catch(err => console.error(err));
    }

    return (
        <div className="cadastroVaga">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <div className="titulo">
                <img src={add} alt="nova vaga" />
                <h1>Nova Vaga</h1>
            </div>
            <div className='box'>
                {/* <Header/> */}
                <div className="form">
                    <form action="formulario" onSubmit={event => {
                        event.preventDefault();
                        Cadastrar();
                    }}>
                        <input className="inputs" type="Text" name="titulovaga" placeholder="Nome Vaga" required value={NomeVaga} onChange={e => setNomeVaga(e.target.value)} />
                        <select name='IdFormaContratacao' value={IdFormaContratacao} placeholder='FormaContratacao' onChange={e => setIdFormaContratacao(e.target.value)} required>
                            <option value='0' disabled >Forma de Contratacao</option>
                            {
                                FormaContratacaomap.map((item: any) =>{ //map = uma lista
                                    return (<option key={item.idFormaContratacao} value={item.idFormaContratacao}>{item.nomeFormaContratacao}</option>)
                                })
                            }
                        </select>

                        <select name='idareavaga' placeholder='IdAreaVaga' value={IdAreaVaga} onChange={e => setIdAreaVaga(e.target.value)} required>
                            <option value='0' disabled >Area</option>
                            {
                                AreaVagamap.map((item: any) =>{
                                    console.log(item.IdAreaVaga)
                                    return (<option key={item.idAreaVaga} value={item.idAreaVaga}>{item.nomeAreaVaga}</option>)
                            
                                })
                            }
                        </select> 
                        <input className="inputs" type="Text" name="salario" placeholder="Salario" required value={Salario} onChange={e => setSalario(e.target.value)} />
                        <input className="inputs" type="Text" name="descricao" placeholder="Descrição" required value={Descricao} onChange={e => setDescricao(e.target.value)} />

                        <div className="row1">
                            <input className="inputs" type="Text" name="requisitos" placeholder="Requisitos" required value={Requisitos} onChange={e => setRequisitos(e.target.value)} />
                        </div>

                        <div className="botoes">
                            <ButtonFull
                                name="Cadastrar"
                                tamanho="lg" />
                        </div>

                    </form>
                </div>
            </div>





            <Footer />
        </div>
    );
}
export default CadastrarVagas;