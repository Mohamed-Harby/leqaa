entityName=$1
projectName=$2
cd ./$projectName.Domain
rm -rf $entityName

domainEntityPath=./$entityName/$entityName.cs
rm $domainEntityPath

cd ..
cd $projectName.Application

interfaceName=I${entityName}Repository
repositoryInterfacePath="./Interfaces/${interfaceName}.cs"
rm $repositoryInterfacePath

interfacesNamespace=$projectName.Application.Interfaces


cd ..
cd $projectName.Persistence

repositoryFilePath=./Repositories/${entityName}Repository.cs
rm $repositoryFilePath



configurationFilePath=./Configurations/${entityName}Configuration.cs
rm $configurationFilePath



dependencyInjectionFilePath=./DependencyInjection/PersistenceDependencyInjection.cs
sed -i "/services.AddScoped<I${entityName}Repository,${entityName}Repository>/d" $dependencyInjectionFilePath






