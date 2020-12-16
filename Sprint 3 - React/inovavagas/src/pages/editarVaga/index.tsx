import React, { useEffect, useState } from 'react';
import ButtonFull from '../../components/button/index';
import './style.css';
import { Link, useHistory } from 'react-router-dom';
// import imgUSenaiInova from '../../assets/images/senai_Inova.png';
import Footer from '../../components/footer/index';
import Header from '../../components/header/index';
import editar from '../../assets/images/canetinha_Cinza.png';
import { Modal } from 'react-bootstrap';
import SuasVagasPostadas from '../SuasVagasPostadas';


function EditarVaga() {
    useEffect(() => {
        listarAreaVaga();
        FormaContratacao();
    }, [])

    useEffect(() => {
        refresh();
    }, [])

    const [FormaContratacaomap, setFormaContratacaomap] = useState([]); //Para lista
    const [AreaVagamap, setAreaVagamap] = useState([]);
    const [IdVaga, setIdVaga] = useState(0);
    const [NomeVaga, setNomeVaga] = useState('');
    const [Descricao, setDescricao] = useState('');
    const [Requisitos, setRequisitos] = useState('');
    const [Salario, setSalario] = useState('');
    const [IdEmpresa, setIdEmpresa] = useState(0);
    const [IdFormaContratacao, setIdFormaContratacao] = useState('0');
    const [IdAreaVaga, setIdAreaVaga] = useState('0');


    const queryString = window.location.search;

    const urlParams = new URLSearchParams(queryString);

    const idEditar = urlParams.get('id');


    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

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

    const refresh = () => {
        fetch('http://localhost:5000/api/Vaga/' + idEditar, {
            method: 'GET',
            headers: {
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .then(dados => {
                setIdVaga(dados.IdVaga);
                setNomeVaga(dados.NomeVaga);
                setIdFormaContratacao(dados.IdFormaContratacao);
                setIdAreaVaga(dados.IdAreaVaga);
                setSalario(dados.Salario);
                setDescricao(dados.Descricao);
                setRequisitos(dados.Requisitos);
                console.log(NomeVaga);
            })
    }

    const salvarEditar = (id: any) => {
        const form = {
            nomeVaga: NomeVaga,
            descricao: Descricao,
            requisitos: Requisitos,
            vagaAtiva: true,
            salario: Salario,
            idFormaContratacao: parseInt(IdFormaContratacao),
            idAreaVaga: parseInt(IdAreaVaga),
        }
        fetch('http://localhost:5000/api/Vaga/' + id, {
            method: 'PUT',
            body: JSON.stringify(form),
            headers: {
                'content-type': 'application/json',
                authorization: 'Bearer' + localStorage.getItem('token-inova')
            }
        })
            .then(() => {
                setIdVaga(0);
                setNomeVaga('');
                setIdFormaContratacao('0');
                setIdAreaVaga('0');
                setDescricao('');
                setRequisitos('');
                setSalario('');
                return (
                    <Modal show={show} onHide={handleClose}>
                        <Modal.Header closeButton>
                            <Modal.Title>Concluído!</Modal.Title>
                        </Modal.Header>
                        <Modal.Body>A vaga foi alterada com sucesso</Modal.Body>
                        <Modal.Footer>
                            <ButtonFull name="Voltar" onClick={() => SuasVagasPostadas} />
                        </Modal.Footer>
                    </Modal>)
            })
            .catch(e => { console.error(e) });
    }


    return (
        <div className="cadastroVaga">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <div className="titulo">
                <img src={editar} alt="nova vaga" />
                {/* <h1>{NomeVaga}</h1> */}
                <h3>Editar Vaga</h3>
            </div>
            <div className='boxEditar'>
                {/* <Header/> */}
                <div className="form">
                    <form action="formulario" onSubmit={event => {
                        event.preventDefault()
                        salvarEditar(idEditar)
                    }}>
                        <input className="inputs" type="Text" name="titulovaga" placeholder="Nome Vaga" value={NomeVaga} onChange={e => setNomeVaga(e.target.value)} />
                        <select name='IdFormaContratacao' value={IdFormaContratacao} placeholder='FormaContratacao' onChange={e => setIdFormaContratacao(e.target.value)} >
                            <option value='0' disabled >Forma de Contratacao</option>
                            {
                                FormaContratacaomap.map((item: any) => { //map = uma lista
                                    return <option key={item.idFormaContratacao} value={item.idFormaContratacao}>{item.nomeFormaContratacao}</option>
                                })
                            }
                        </select>

                        <select className="inputs" name='idareavaga' value={IdAreaVaga} placeholder='IdAreaVaga' onChange={e => setIdAreaVaga(e.target.value)} >
                            <option value='0' disabled >Area</option>
                            {
                                AreaVagamap.map((item: any) => {
                                    return <option key={item.idAreaVaga} value={item.idAreaVaga}>{item.nomeAreaVaga}</option>
                                })
                            }
                        </select>
                        <input className="inputs" type="Text" name="salario" placeholder="Salario" value={Salario} onChange={e => setSalario(e.target.value)} />
                        <input className="inputs" type="Text" name="descricao" placeholder="Descrição" value={Descricao} onChange={e => setDescricao(e.target.value)} />

                        <div className="row1">
                            <input className="inputs" type="Text" name="requisitos" placeholder="Requisitos" value={Requisitos} onChange={e => setRequisitos(e.target.value)} />
                        </div>
                        <div className="botoes">
                            <ButtonFull name="Editar" />
                        </div>
                    </form>
                </div>
            </div>






            <Footer />
        </div>
    );
}
export default EditarVaga;