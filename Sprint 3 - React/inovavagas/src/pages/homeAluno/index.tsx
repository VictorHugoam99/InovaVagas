import React, { useEffect, useState} from 'react';
import {Link, useHistory } from 'react-router-dom';
import './style.css';
import Header from '../../components/header/index';
import Button from '../../components/button'
import Footer from '../../components/footer/index';
import FormControl from 'react-bootstrap/FormControl';
import CardAluno from '../../components/cardAluno/index';
import SearchBar from '../../components/searchBar/index';
import ButtonFull from '../../components/button';



function HomeAluno() {
    const history = useHistory();

    const [idVaga, setIdVaga] = useState(0);
    const [vaga, setVaga] = useState('');

    const[vagas, setVagas] = useState([]);

    useEffect(() => {
        listar();
    }, []);

    const listar = () => {
        fetch('http://localhost:5000/api/Vaga', {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setVagas(dados);
                console.log('' + vagas)

            })
            .catch(err => console.error(err));
    }

    const visualizarVaga = (id : number) => {

        fetch('http://localhost:5000/api/Vaga/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then( resp => resp.json())
            .then( dados => {
                setIdVaga(dados.idVaga);
                console.log(id);
                // localStorage.setItem( 'IdVaga', String(idVaga))
                history.push(`/visualizarVaga?id=${id}`)
            })
            .catch(err => console.error(err));
    }


    return(
        <div className="home-aluno">
        <div className="bg-color">
        <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'}/>
            <div className="main">
                <div className="searchBar">
                    <h3>Filtre sua procura:</h3>
                    <div className="search">
                        <FormControl type='text' placeholder='Palavra-chave' bsPrefix='input'></FormControl>
                        <FormControl type='text' placeholder='Empresa' bsPrefix='input'></FormControl>
                        <FormControl type='text' placeholder='Linguagem' bsPrefix='input'></FormControl>
                    <button className="botao-buscar">Buscar</button>
                    </div>
                </div>
            </div>
        </div>
            <div className="cardVaga-container">
                {
                    vagas.map((item:any)=> 
                    { 
                        return <CardAluno tittle={item.nomeVaga} onClick={() => visualizarVaga(item.idVaga)} text={item.descricao} ></CardAluno>
                    })
                }
        </div>
        <Footer/>
    </div>
    )
}

export default HomeAluno;