const baseUrl = '/api/Video';


export const getVideo = (id) => {
    return fetch(`${baseUrl}/GetByIdWithComments/${id}`).then((res) => res.json());
};

export const getAllVideos = () => {
    return fetch(baseUrl)
        .then((res) => res.json())
};

export const getAllVideosWithComments = () => {
    return fetch(baseUrl + '/GetWithComments')
        .then((res) => res.json())
};

export const Search = (searchQ, descendingOrder) => {
    return fetch(baseUrl + `/Search?` + new URLSearchParams({q:searchQ, sortDesc:descendingOrder}))
        .then((res) => res.json())
};

export const addVideo = (video) => {
    return fetch(baseUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(video),
    });
};