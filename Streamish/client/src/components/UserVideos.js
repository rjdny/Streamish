import React, { useEffect, useState } from "react";
import { ListGroup, ListGroupItem } from "reactstrap";
import { useParams } from "react-router-dom";
import Video from "./Video";
import { getAllVideos } from "../modules/videoManager";
import VideoDetails from "./VideoDetails";

export const UserVideos = () =>{
    const { id } = useParams();
    const [videos, setVideos] = useState([])

    useEffect(() => {
        getUserVids()
    }, [])


    const getUserVids = () => {
        getAllVideos().then((vids) => { setVideos(vids.filter((vid) => vid.userProfile.id == id)) });
    }

    return (<>
            {(videos[0] == undefined) ? <></> : <h2>{videos[0].userProfile.name}'s Videos</h2>}
            <section style={{display:'flex',flexWrap:'wrap',marginLeft:'200px', marginTop:'75px'}}>
                {videos.map(v =>
                    <Video video={v}></Video>
                )}
            </section>
    </>)
}

