<?php
$workingfolder = dirname(__FILE__);
if(!file_exists("clients.php")) {echo "Missing : " . $workingfolder . "/client.php. Reinstallation May be required."; exit;}

file_put_contents("victims.txt", "");
if(!file_exists("victims.txt")) {echo "Folder don't have WRITE access. Permissions need to be adjusted."; exit;}
mkdir("logs" , 0777 , true);
chmod("logs", 0777);
if(!is_dir("logs")) { echo "Script don't have WRITE access. Permissions need to be adjusted.";exit;}
mkdir("victims" , 0777 , true);
chmod("victims", 0777);
if(!is_dir("victims")) { echo "Script don't have WRITE access. Permissions need to be adjusted.";exit;}
mkdir("files" , 0777 , true);
chmod("files", 0777);
if(!is_dir("files")) { echo "Script don't have WRITE access. Permissions need to be adjusted.";exit;}

echo "success";
?>