import React from 'react';
import {Card} from 'react-bootstrap';
import {Link} from 'react-router-dom';
import './style.css';

interface CardProps{
    img: any;
    title: string;
    description?: string;
}

const CardEmpresa:React.FC<CardProps> = ({img, title, description, ...rest}) => {
    return(
        <div className="cardEmpresa">
            <Link className="container" to="/"/>
                <Card bsPrefix="main-card">
                    <Card.Body bsPrefix="card-body">
                        <Card.Title bsPrefix="card-title">{title}</Card.Title>
                        <Card.Img bsPrefix="card-img" src={img}></Card.Img>
                        <Link className="perfil" to="/perfilEmpresa">Ver Perfil</Link>
                    </Card.Body>
                </Card>
        </div>
    )
}

export default CardEmpresa;