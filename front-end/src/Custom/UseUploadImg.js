import { useEffect, useState } from "react";

export const UseUploadImg = (image) => {
    const [base64String, setBase64String] = useState();

    var file = image.target.files[0];
    console.log(file);
    var reader = new FileReader();
    console.log("next");
    reader.onload = function () {
        setBase64String(reader.result.replace("data:", "").replace(/^.+,/, ""));
        // dispatch(setProfilePicture({ profilePicture: { profilePicture: reader.result.replace("data:", "").replace(/^.+,/, "") }, token: token }));
    };
    reader.readAsDataURL(file);

    return base64String;
};