﻿import React, { useEffect, useState } from "react";
import { getAllVideos, getAllVideosWithComments, Search } from "../modules/videoManager";
import { Card, CardBody, CardHeader, Button} from "reactstrap";
import Video from "./Video";
import VideoForm from "./VideoForm";

const VideoList = () => {
    const [searchQ, setSearchQ] = useState('');
    const [videos, setVideos] = useState([]);
    const [descending, setDescending] = useState(false)

    const getVideos = () => {
        getAllVideosWithComments().then(videos => setVideos(videos));
    };

    useEffect(() => {
        getVideos();
    }, []);

    useEffect(() => {
        Search(searchQ, descending).then((videos) => setVideos(videos))
    },[searchQ, descending])


    return (
        <div style={{marginTop:'20px'}}>
            <div style={{position:'absolute', marginLeft:'20px', marginTop:'-20px'}}>
                <h1>Streamish</h1>
            </div>
            <input style={{width:"300px"}} id="searchq" type={'Text'}></input>
            <button onClick={() => {setSearchQ(document.querySelector('#searchq').value)}}>Search</button>
            <section>
            <label><input
                id="searchdesc" 
                onChange={() => {setDescending(document.querySelector('#searchdesc').checked)}} 
                type={'checkbox'}>
                </input> Descending Order</label>
            </section>
            <VideoForm getVideos={getVideos}></VideoForm>
            <section style={{display:'flex',flexWrap:'wrap',marginLeft:'250px'}}>
                {videos.map(v =>
                    <Video video={v}></Video>
                )}
            </section>
        </div>
    );
}

export default VideoList;