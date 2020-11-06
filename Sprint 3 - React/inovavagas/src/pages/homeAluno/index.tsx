import React, { useEffect, useState} from 'react';
import {Link, useHistory } from 'react-router-dom';
import './style.css';
import Header from '../../components/header/index';
import Button from '../../components/button'
// import Footer from '../../components/footer/index';
import CardAluno from '../../components/cardAluno/index';
import SearchBar from '../../components/searchBar/index';



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

    const visualizarVaga = (nomeVaga : string) => {

        fetch('http://localhost:5000/api/Vaga/' + nomeVaga, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('token-inova')
            }
        })
            .then( resp => resp.json())
            .then( dados => {
                setVaga(dados.nomeVaga);
                localStorage.setItem( 'Vaga' ,vaga)
                history.push('/visualizacaoVaga')
            })
            .catch(err => console.error(err));
    }

    return(
        <div>
            <Header pageWrapId={'page-wrap'} outerContainerId={'outer-container'}/>
            <main>
                <div className="bg-color">
                <div className="searchBar">
                    <SearchBar></SearchBar>
                <Button name="Buscar" tamanho="lg"></Button>
            </div>
                </div>
            <hr/>
            <div>
                {
                    vagas.map((item:any)=> 
                    { 
                        return <CardAluno tittle={item.nomeVaga} onClick={() => visualizarVaga(item.nomeVaga)} text={item.descricao} ></CardAluno>
                    })
                }
            </div>
            </main>
            {/* <Footer/> */}
        </div>
    )
}

export default HomeAluno;