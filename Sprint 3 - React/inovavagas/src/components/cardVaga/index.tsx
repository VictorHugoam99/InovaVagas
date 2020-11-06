import React, {useState}from 'react';
import './style.css';
import { Card } from 'react-bootstrap';
import inova from '../../assets/images/inovaVermelho.png';
import editar from '../../assets/images/canetinha_Cinza.png';
import apagar from '../../assets/images/lixo_Cinza.png';
import mais from '../../assets/images/mais_Cinza.png'
import { Link } from 'react-router-dom';
import Modals from '../../components/modal/index';
import ButtonFull from '../../components/button/index';

interface CardVagaProps {
    tittle: string;
    text: string;
}

const CardVaga: React.FC<CardVagaProps> = ({ tittle, text, ...rest }) => {
    
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    return (
        <div>
            <Card bsPrefix="main-card">
                <Card.Body bsPrefix="card-body">
                    <div>
                        <Card.Title bsPrefix="card-tittle">{tittle}</Card.Title>
                    <Card.Text bsPrefix="card-info"> 
                        <ul>
                            <li>Tipo de vaga</li>
                            <li>Turno da vaga</li>
                        </ul> 
                    </Card.Text>                   
                    <div className="imagens">
                        <Card.Img src={inova} ></Card.Img>
                        <div className="atalhos">
                            <Link to="/suasVagasPostadas" onClick={handleShow}>
                                <Card.Img src={editar} bsPrefix="editar"></Card.Img>
                            </Link>
                            <Modals tittle="Concluído" text="A vaga foi editada com sucesso!">
                                
                            </Modals>
                            <a href="">
                                <Card.Img src={apagar} ></Card.Img>
                            </a>
                        </div>
                    </div>
                    </div>
                    
                    <Card.Text bsPrefix="card-text1">Descrição da vaga:</Card.Text>
                    <div>
                        <Card.Text bsPrefix="card-text">{text}</Card.Text>
                    </div>
                </Card.Body>
            </Card>
        </div>
    )
}

export default CardVaga;