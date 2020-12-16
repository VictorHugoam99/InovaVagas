import React, { useEffect, useState } from 'react';
import {Link, useHistory } from 'react-router-dom';
import './style.css';
import Header from '../../components/header/index';
import Footer from '../../components/footer/index';
import { Col, Container, Row } from 'react-bootstrap';
import inova from '../../assets/images/inovaVermelho.png';
import Button from '../../components/button/index';
import { parseJwt } from '../../services/auth';

function VisualizarVaga() {
    const [nomeVaga, setNomeVaga] = useState('');
    const [descricao, setDescricao] = useState('');
    const [requisitos, setRequisitos] = useState('');
    const [endereco, setEndereco] = useState('');
    const [salario, setSalario] = useState('');

    const [idEmpresa, setIdEmpresa] = useState(0);
    const [nomeFantasia, setNomeFantasia] = useState('');
    const [emailContato, setEmailContato] = useState('');
    const [telefone, setTelefone] = useState('');
    const [celular, setCelular] = useState('');
    const [ramoAtuacao, setRamoAtuacao] = useState('');
    const [tamanhoEmpresa, setTamanhoEmpresa] = useState('');

    const [idAreaVaga, setIdAreaVaga] = useState('0');
    const [nomeAreaVaga, setNomeAreaVaga] = useState('');
    const [idFormaContratacao, setIdFormaContratacao] = useState('0');
    const [nomeFormaContratacao, setNomeFormaContratacao] = useState('');

    const queryString = window.location.search;

    const urlParams = new URLSearchParams(queryString);

    const id = urlParams.get('id')

    useEffect(() => {
        visualizarVaga();
    }, []);

    const candidatar = () => {
        const candidatoForm = {
            idAluno: parseJwt().Id,
            idVaga: id
        }

        fetch('http://localhost:5000/api/Candidatura', {
            method: 'POST',
            body: JSON.stringify(candidatoForm),
            headers: {
                'content-type':'application/json',
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
        .then(resp => {
            if(resp.status === 200)
            {
                alert('Candidatura efetuada');
            }
            else
            {
                alert('Houve um erro ao candidatar-se');
            }
        })
    }

    const visualizarVaga = () => {

        // var id = window.getParameterByName("id");

        fetch('http://localhost:5000/api/Vaga/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(resp => resp.json())
            .then(data => {
                setNomeVaga(data.nomeVaga);
                setDescricao(data.descricao);
                setRequisitos(data.requisitos);
                setEndereco(data.endereco);
                setSalario(data.salario);
                setIdEmpresa(data.idEmpresa);
                setIdAreaVaga(data.idAreaVaga);
                setIdFormaContratacao(data.idFormaContratacao);

                fetch('http://localhost:5000/api/Empresa/' + data.idEmpresa, {
                    method: 'GET',
                    headers: {
                        authorization: 'Bearer ' + localStorage.getItem('token-inova')
                    }
                })
                    .then(resp => resp.json())
                    .then(data => {
                        setNomeFantasia(data.nomeFantasia);
                        setEmailContato(data.emailContato);
                        setTelefone(data.telefone);
                        setCelular(data.celular);
                        setRamoAtuacao(data.ramoAtuacao);
                        setTamanhoEmpresa(data.tamanhoEmpresa);
                    })
                    .catch(err => console.error(err));

                fetch('http://localhost:5000/api/AreaVaga/' + data.idAreaVaga, {
                    method: 'GET',
                    headers: {
                        authorization: 'Bearer ' + localStorage.getItem('token-inova')
                    }
                })
                    .then(resp => resp.json())
                    .then(data => {
                        setNomeAreaVaga(data.nomeAreaVaga);
                    })
                    .catch(err => console.error(err));

                fetch('http://localhost:5000/api/FormaContratacao/' + data.idFormaContratacao, {
                    method: 'GET',
                    headers: {
                        authorization: 'Bearer ' + localStorage.getItem('token-inova')
                    }
                })
                    .then(resp => resp.json())
                    .then(data => {
                        setNomeFormaContratacao(data.nomeFormaContratacao);
                    })
                    .catch(err => console.error(err));
            })
            .catch(err => console.error(err));
    }

    return (
        <div className="visualizarVaga">
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'} />
            <main>
                <Container className="content">
                    <Row xs={1} md={2} lg={9}>
                        <Col><h1>{nomeVaga}</h1></Col>
                        <Col> <img src={inova}></img> </Col>
                        {nomeFantasia != null?  <Col><h2>{nomeFantasia}</h2></Col> : '' }
                        <Col><h2>Endereço: {endereco}</h2></Col>
                        <Col><h2>Salário: {salario}</h2></Col>
                    </Row>

                    <Row xs={1}>

                        {telefone != null?  <Col><h2>Telefone: {telefone}</h2></Col> : '' }
                        {emailContato != null? <Col><h2>Email para Contato: {emailContato}</h2></Col>: '' }
                        {requisitos != null? <Col><h2>Requisitos: {requisitos}</h2></Col>: '' }
                    </Row>

                    <Row >
                        <Col><h2>Área de atuação: {nomeAreaVaga}</h2></Col>
                        <Col><h2>Forma de Contratação: {nomeFormaContratacao}</h2></Col>
                    </Row>
                    <div className="btn">
                        <div className="candidatar">
                            <Button onClick={() => candidatar()}name="Candidatar-se"></Button> 
                        </div>
                        <div className="voltar">
                            <Link to='/aluno'><Button name="Voltar p/ vagas"></Button></Link>
                        </div>
                        <div className="atalho">
                            <a href="/perfilEmpresa"> Visualizar perfil da empresa </a>
                        </div>
                    </div>
                    <div className="desc">
                        <Row xs={2}>
                            <Col>{descricao}</Col>
                        </Row>
                    </div>

                </Container>
            </main>
            <Footer />
        </div>
    )
}

export default VisualizarVaga;