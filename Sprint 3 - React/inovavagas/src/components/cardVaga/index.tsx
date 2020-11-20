import React, { useState } from 'react';
import './style.css';
import { Card } from 'react-bootstrap';
import inova from '../../assets/images/inovaVermelho.png';
import editar from '../../assets/images/canetinha_Cinza.png';
import apagar from '../../assets/images/lixo_Cinza.png';
import mais from '../../assets/images/mais_Cinza.png'
import { Link } from 'react-router-dom';
import ButtonFull from '../../components/button/index';
import {Modal} from 'react-bootstrap';
import Button from 'react-bootstrap';

interface CardVagaProps {
    tittle: string;
    text: string;
}

const CardVaga: React.FC<CardVagaProps> = ({ tittle, text, ...rest }) => {

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    return (
        <div className="cardVaga">
            <Card bsPrefix="main-card">
                <Card.Body bsPrefix="card-body">
                    <div className="cardText-container">
                        <Card.Title bsPrefix="card-tittle">{tittle}</Card.Title>
                        <Card.Text bsPrefix="card-info">
                            <ul>
                                <li>Tipo de vaga</li>
                                <li>Turno da vaga</li>
                            </ul>
                        </Card.Text>
                        <div className="content-container">
                            <Card.Text bsPrefix="card-text1">Descrição da vaga:</Card.Text>
                            <Card.Text bsPrefix="card-text">{text}</Card.Text>
                        </div>
                    </div>
                    <div className="imagens">
                        <div className="imgEmpresa-container">
                            <Card.Img src={inova} bsPrefix="imgEmpresa" ></Card.Img>
                        </div>
                        <div className="atalhos">
                            <Link to="/suasVagasPostadas">
                                <img src={editar} />
                            </Link>
                            <button onClick={handleShow}>
                                <img src={apagar} />
                            </button>
                        </div>
                        <Modal show={show} onHide={handleClose}>
                            <Modal.Header closeButton>
                                <Modal.Title>Atenção!</Modal.Title>
                            </Modal.Header>
                            <Modal.Body>Deseja apagar essa vaga?</Modal.Body>
                            <Modal.Footer>
                                <ButtonFull name="Sim" onClick={handleClose}/>
                                <ButtonFull name="Não" onClick={handleClose}/>
                            </Modal.Footer>
                        </Modal>
                    </div>

                </Card.Body>
            </Card>
        </div>
    )
}

export default CardVaga;