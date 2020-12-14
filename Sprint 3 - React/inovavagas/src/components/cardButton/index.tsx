import React from 'react';
import { Link } from 'react-router-dom'
import Card from 'react-bootstrap/Card';
import '../../components/cardButton/style.css';

interface CardButtonProps {
    title: string;
    img: any;
    description?: string;
}

const CardButton: React.FC<CardButtonProps> = ({ title, img, description }) => {
    return (
        <div className="card-button">
            <Card bsPrefix='main-card'>
                <Card.Body bsPrefix='card-body'>
                    <Card.Img bsPrefix='card-img' src={img} ></Card.Img>
                    <Card.Title bsPrefix='card-title'>{title}</Card.Title>
                    <Card.Text bsPrefix='card-text'>{description}</Card.Text>
                </Card.Body>
            </Card>
        </div>
    );
}

export default CardButton;