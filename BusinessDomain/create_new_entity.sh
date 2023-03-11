entityName=$1
projectName=$2
cd ./$projectName.Domain
mkdir $entityName

domainEntityPath=./$entityName/$entityName.cs
touch $domainEntityPath

cat > $domainEntityPath <<- EOM
namespace $projectName.Domain;
public class $entityName:BaseEntity{

}
EOM

cd ..
cd $projectName.Application

interfaceName=I${entityName}Repository
repositoryInterfacePath="./Interfaces/${interfaceName}.cs"
touch $repositoryInterfacePath

interfacesNamespace=$projectName.Application.Interfaces
cat > $repositoryInterfacePath <<- EOM
namespace $interfacesNamespace;
using $projectName.Domain;
using CommonGenericClasses;
public interface $interfaceName:IBaseRepo<$entityName>{
    
}
EOM

cd ..
cd $projectName.Persistence

repositoryFilePath=./Repositories/${entityName}Repository.cs
touch $repositoryFilePath

cat > $repositoryFilePath <<-EOM
namespace $projectName.Persistence.Repositories;
using $projectName.Application.Interfaces;
using $projectName.Domain;
using CommonGenericClasses;
public class ${entityName}Repository:BaseRepo<$entityName>,$interfaceName{
     public ${entityName}Repository(ApplicationDbContext context) : base(context)
     {
     }
}
EOM

configurationFilePath=./Configurations/${entityName}Configuration.cs
touch $configurationFilePath

cat > $configurationFilePath <<-EOM
namespace $projectName.Persistence.Configurations;
using $projectName.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ${entityName}Configuration : BaseConfiguration<$entityName>
    {
        public override void Configure(EntityTypeBuilder<$entityName> builder)
        {
            builder.ToTable("${entityName}s");
            base.Configure(builder);
        }
    }
EOM

dependencyInjectionFilePath=./DependencyInjection/PersistenceDependencyInjection.cs
sed -i "0,/services.AddScoped.*\$/s//&\nservices.AddScoped<$interfaceName,${entityName}Repository>();/" $dependencyInjectionFilePath






