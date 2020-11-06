import React from 'react';
import './style.css';
import { Card, Button } from 'react-bootstrap';
import inova from '../../assets/images/inovaVermelho.png';

interface CardAdmProps {
    tittle: string;
    text: string;
    emailEmpresa: string;
    numeroEmpresa:any;
}

const CardAdm: React.FC<CardAdmProps> = ({ tittle, text,emailEmpresa,numeroEmpresa, ...rest }) => {
    return (
        <div>
            <Card.Link>
            <Card bsPrefix="main-card">
                <Card.Body bsPrefix="card-body">
                    <div>
                        <Card.Title bsPrefix="card-tittle">{tittle}</Card.Title>
                    <Card.Text bsPrefix="card-info"> 
                        <ul>
                            <li>{emailEmpresa}</li>
                            <li>{numeroEmpresa}</li>
                        </ul> </Card.Text>                   
                        <Card.Img src={inova}></Card.Img>
                        </div>
                    
                    <Card.Text bsPrefix="card-text1">Sobre a empresa:</Card.Text>
                    <div>
                        <Card.Text bsPrefix="card-text">{text}</Card.Text>
                    </div>

                    <div className="btn">
                        <Button variant="primary">Aprovar</Button>
                        <Button variant="secondary">Recusar</Button>
                    </div>
                </Card.Body>
            </Card>
            </Card.Link>
        </div>
    )
}

export default CardAdm;