import React from 'react';
import './style.css';
import { Card } from 'react-bootstrap';
import img from '../../assets/images/inovaVermelho.png';

interface CardAlunoProps {
    tittle: string;
    text: string;
    onClick?: any;
    emailAluno?: string;
    telefoneAluno?: string;
}

const CardAluno: React.FC<CardAlunoProps> = ({ tittle, text, onClick, ...rest }) => {
    return (
        <div className="cardAluno">
            <Card.Link>
                <Card bsPrefix="main-card">

                    <Card.Body bsPrefix="card-body" onClick={onClick}>
                        <div>
                            <Card.Title bsPrefix="card-tittle">{tittle}</Card.Title>
                            <Card.Text bsPrefix="card-info">

                            </Card.Text>
                        </div>
                            <Card.Img bsPrefix="card-img" src={img}></Card.Img>

                        <Card.Text bsPrefix="card-text1">Descrição:</Card.Text>
                        <div>
                            <Card.Text bsPrefix="card-text">{text}</Card.Text>
                        </div>
                    </Card.Body>
                </Card>
            </Card.Link>
        </div>
    )
}

export default CardAluno;